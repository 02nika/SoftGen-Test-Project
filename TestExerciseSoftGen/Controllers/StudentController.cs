using DataAccess.Data.Abtract;
using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestExerciseSoftGen.Model;

namespace TestExerciseSoftGen.Controllers
{
    [Route("student/")]
    public class StudentController : ControllerBase
    {
        #region variables and ctors
        private readonly IStudentContext _student;

        public StudentController(IStudentContext student)
        {
            _student = student;
        }
        #endregion

        #region Endpoints
        [HttpPost("add")]
        public async Task<ActionResult<string>> Add(StudentViewModel student)
        {
            var success = await _student.AddStudentAsync(new Student
            {
                Firstname = student.Firstname,
                Lastname = student.Lastname,
                Email = student.Email,
                PersonalId = student.PersonalId,
                BirthDate = student.BirthDate
            });

            if (success)
                return Ok("student added successfully");
            else return StatusCode(500);
        }

        [HttpPut("update")]
        public async Task<ActionResult<string>> Update(Student student)
        {
            var success = await _student.UpdateStudentAsync(student);

            if (success)
                return Ok("student updated successfully");
            else return StatusCode(500);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<string>> Delete(int studentId)
        {
            if (studentId <= 0) return BadRequest("request is not valid");

            var success = await _student.DeleteStudentAsync(studentId);

            if (success)
                return Ok("student deleted successfully");
            else return StatusCode(500);
        }

        [HttpGet("search-students")]
        public async Task<ActionResult<string>> SearchStudents(StudentSearchModel searchModel)
        {
            var students = await _student.SearchStudentsAsync(searchModel);

            return JsonConvert.SerializeObject(students);
        }
        #endregion
    }
}
