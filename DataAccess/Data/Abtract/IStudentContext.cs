using DataAccess.Model;
using TestExerciseSoftGen.Model;

namespace DataAccess.Data.Abtract
{
    public interface IStudentContext
    {
        Task<bool> AddStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(int studentId);
        Task<bool> UpdateStudentAsync(Student student);
        Task<List<Student>> SearchStudentsAsync(StudentSearchModel searchModel);
    }
}