using DataAccess.Model;
using DataAccess.Model.Search;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestExerciseSoftGen.Model;

namespace TestExerciseSoftGen.Controllers
{
    [Route("teacher/")]
    public class TeacherController : ControllerBase
    {
        #region variables and ctors
        private readonly ITeacherContext _teacher;

        public TeacherController(ITeacherContext teacher)
        {
            _teacher = teacher;
        }
        #endregion

        #region Endpoints
        [HttpPost("add")]
        public async Task<ActionResult<string>> Add(TeacherViewModel teacher)
        {
            var success = await _teacher.AddTeacherAsync(new Teacher
            {
                Firstname = teacher.Firstname,
                Lastname = teacher.Lastname,
                Email = teacher.Email,
                PersonalId = teacher.PersonalId,
                BirthDate = teacher.BirthDate
            });

            if (success)
                return Ok("teacher added successfully");
            else return StatusCode(500);
        }

        [HttpPut("update")]
        public async Task<ActionResult<string>> Update(Teacher teacher)
        {
            var success = await _teacher.UpdateTeacherAsync(teacher);

            if (success)
                return Ok("teacher updated successfully");
            else return StatusCode(500);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<string>> Delete(int teacherId)
        {
            if (teacherId <= 0) return BadRequest("request is not valid");

            var success = await _teacher.DeleteTeacherAsync(teacherId);

            if (success)
                return Ok("teacher deleted successfully");
            else return StatusCode(500);
        }

        [HttpGet("search-teachers")]
        public async Task<ActionResult<string>> SearchTeachers(TeacherSearchModel searchModel)
        {
            var teachers = await _teacher.SearchTeachersAsync(searchModel);

            return JsonConvert.SerializeObject(teachers);
        }
        #endregion
    }
}
