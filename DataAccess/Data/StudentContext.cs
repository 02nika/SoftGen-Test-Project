using DataAccess.Data.Abtract;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using TestExerciseSoftGen.Model;

namespace DataAccess.Data
{
    public class StudentContext : IStudentContext
    {
        private readonly DataContext _context;

        public StudentContext(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> AddStudentAsync(Student student)
        {
            try
            {
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            try
            {
                var s1 = await _context.Students.Where(item => item.Id == student.Id).FirstOrDefaultAsync();
                if (s1 == null) return false;

                s1.Firstname = string.IsNullOrEmpty(student.Firstname) ? s1.Firstname: student.Firstname;
                s1.Lastname = string.IsNullOrEmpty(student.Lastname) ? s1.Lastname : student.Lastname;
                s1.BirthDate = student.BirthDate ?? s1.BirthDate;
                s1.Email = string.IsNullOrEmpty(student.Email) ? s1.Email : student.Email;
                s1.PersonalId = string.IsNullOrEmpty(student.PersonalId) ? s1.PersonalId : student.PersonalId;

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteStudentAsync(int studentId)
        {
            try
            {
                var s1 = await _context.Students.Where(item => item.Id == studentId).FirstOrDefaultAsync();
                if (s1 == null) return false;

                _context.Students.Remove(s1);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Student>> SearchStudentsAsync(StudentSearchModel searchModel)
        {
            var searchQuery = (from s in _context.Students
                               select s);

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
