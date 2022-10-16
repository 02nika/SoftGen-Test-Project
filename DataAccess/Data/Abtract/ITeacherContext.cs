using DataAccess.Model;
using DataAccess.Model.Search;

namespace DataAccess.Data
{
    public interface ITeacherContext
    {
        Task<bool> AddTeacherAsync(Teacher teacher);
        Task<bool> DeleteTeacherAsync(int teacherId);
        Task<List<Teacher>> SearchTeachersAsync(TeacherSearchModel searchModel);
        Task<bool> UpdateTeacherAsync(Teacher teacher);
    }
}