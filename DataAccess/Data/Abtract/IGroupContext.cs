using DataAccess.Model;
using DataAccess.Model.Search;

namespace DataAccess.Data
{
    public interface IGroupContext
    {
        Task<bool> AddGroupAsync(Group group);
        Task<bool> DeleteGroupAsync(int groupId);
        Task<List<Group>> SearchGroupsAsync(GroupSearchModel searchModel);
        Task<bool> UpdateGroupAsync(Group group);
        Task<bool> AddStudentToGroup(int groupId, int studentId);
        Task<bool> RemoveStudentToGroup(int groupId, int studentId);
        Task<bool> AddTeacherToGroup(int groupId, int teacherId);
        Task<bool> RemoveTeacherToGroup(int groupId);
    }
}