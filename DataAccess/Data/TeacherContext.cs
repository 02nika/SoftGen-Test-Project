using DataAccess.Model;
using DataAccess.Model.Search;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class TeacherContext : ITeacherContext
    {
        private readonly DataContext _context;

        public TeacherContext(DataContext context)
        {
            this._context = context;
        }

        public async Task<bool> AddTeacherAsync(Teacher teacher)
        {
            try
            {
                await _context.Teachers.AddAsync(teacher);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateTeacherAsync(Teacher teacher)
        {
            try
            {
                var t1 = await _context.Teachers.Where(item => item.Id == teacher.Id).FirstOrDefaultAsync();
                if (t1 == null) return false;

                t1.Firstname = string.IsNullOrEmpty(teacher.Firstname) ? t1.Firstname : teacher.Firstname;
                t1.Lastname = string.IsNullOrEmpty(teacher.Lastname) ? t1.Lastname : teacher.Lastname;
                t1.BirthDate = teacher.BirthDate ?? t1.BirthDate;
                t1.Email = string.IsNullOrEmpty(teacher.Email) ? t1.Email : teacher.Email;
                t1.PersonalId = string.IsNullOrEmpty(teacher.PersonalId) ? t1.PersonalId : teacher.PersonalId;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteTeacherAsync(int teacherId)
        {
            try
            {
                var s1 = await _context.Teachers.Where(item => item.Id == teacherId).FirstOrDefaultAsync();
                if (s1 == null) return false;

                _context.Teachers.Remove(s1);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Teacher>> SearchTeachersAsync(TeacherSearchModel searchModel)
        {
            var searchQuery = (from t in _context.Teachers
                               select t);

            if (!string.IsNullOrEmpty(searchModel.Firstname))
                searchQuery = searchQuery.Where(item => item.Firstname == searchModel.Firstname);

            if (!string.IsNullOrEmpty(searchModel.Lastname))
                searchQuery = searchQuery.Where(item => item.Lastname == searchModel.Lastname);

            if (!string.IsNullOrEmpty(searchModel.PersonalId))
                searchQuery = searchQuery.Where(item => item.PersonalId == searchModel.PersonalId);

            if (searchModel.BirthDate != null)
                searchQuery = searchQuery.Where(item => item.BirthDate == searchModel.BirthDate);

            return await searchQuery.ToListAsync();
        }

    }
}
