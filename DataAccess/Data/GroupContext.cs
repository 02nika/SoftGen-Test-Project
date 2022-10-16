using DataAccess.Model;
using DataAccess.Model.Search;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class GroupContext : IGroupContext
    {
        private readonly DataContext _context;

        public GroupContext(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddGroupAsync(Group group)
        {
            try
            {
                await _context.Groups.AddAsync(group);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateGroupAsync(Group group)
        {
            try
            {
                var g1 = await _context.Groups.Where(item => item.Id == group.Id).FirstOrDefaultAsync();
                if (g1 == null) return false;

                g1.Name = string.IsNullOrEmpty(group.Name) ? g1.Name : group.Name;
                g1.GroupNumber = group.GroupNumber;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteGroupAsync(int groupId)
        {
            try
            {
                var s1 = await _context.Groups.Where(item => item.Id == groupId).FirstOrDefaultAsync();
                if (s1 == null) return false;

                _context.Groups.Remove(s1);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Group>> SearchGroupsAsync(GroupSearchModel searchModel)
        {
            var searchQuery = (from s in _context.Groups
                               select s);

            if (searchModel.GroupNumber != null)
                searchQuery = searchQuery.Where(item => item.GroupNumber == searchModel.GroupNumber);

            return await searchQuery.ToListAsync();
        }

        public async Task<bool> AddStudentToGroup(int groupId, int studentId)
        {
            try
            {
                var mappings = from gtsm in _context.Group_Student_Mappings
                               where gtsm.GroupId == groupId
                               select gtsm;
                if (mappings.Count() != 0 && mappings.Where(item => item.StudentId == studentId).Count() > 0) return false;

                await _context.Group_Student_Mappings.AddAsync(new Group_Student_Mapping
                {
                    GroupId = groupId,
                    StudentId = studentId
                });
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> RemoveStudentToGroup(int groupId, int studentId)
        {
            try
            {
                var mappings = from gtsm in _context.Group_Student_Mappings
                               where gtsm.GroupId == groupId
                               select gtsm;

                if (mappings.Count() == 0 || mappings.Where(item => item.StudentId == studentId).Count() == 0) return false;

                var res = await mappings.Where(item => item.StudentId == studentId).FirstOrDefaultAsync();

                if (res == null) return false;
                _context.Remove(res);
                await _context.SaveChangesAsync();
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AddTeacherToGroup(int groupId, int teacherId)
        {
            try
            {
                var mappings = from gtsm in _context.Group_Teacher_Mappings
                               where gtsm.GroupId == groupId
                               select gtsm;

                if (mappings.Count() == 0)
                {
                    await _context.Group_Teacher_Mappings.AddAsync(new Group_Teacher_Mapping
                    {
                        GroupId = groupId,
                        TeacherId = teacherId
                    });
                }
                else
                {
                    var res = await mappings.FirstOrDefaultAsync();
                    res.TeacherId = teacherId;
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> RemoveTeacherToGroup(int groupId)
        {
            try
            {
                var mappings = from gtsm in _context.Group_Teacher_Mappings
                               where gtsm.GroupId == groupId
                               select gtsm;

                if (mappings.Count() == 0) return false;
                _context.Group_Teacher_Mappings.RemoveRange(mappings);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
