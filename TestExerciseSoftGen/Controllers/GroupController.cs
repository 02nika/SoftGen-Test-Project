using DataAccess.Model.Search;
using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TestExerciseSoftGen.Model;

namespace TestExerciseSoftGen.Controllers
{
    [Route("group/")]
    public class GroupController : ControllerBase
    {
        #region variables and ctors
        private readonly IGroupContext _group;

        public GroupController(IGroupContext group)
        {
            _group = group;
        }
        #endregion

        #region Endpoints
        [HttpPost("add")]
        public async Task<ActionResult<string>> Add(GroupViewModel group)
        {
            var success = await _group.AddGroupAsync(new Group
            {
                Name = group.Name,
                GroupNumber = group.GroupNumber
            });

            if (success)
                return Ok("group added successfully");
            else return StatusCode(500);
        }

        [HttpPut("update")]
        public async Task<ActionResult<string>> Update(Group group)
        {
            var success = await _group.UpdateGroupAsync(group);

            if (success)
                return Ok("group updated successfully");
            else return StatusCode(500);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<string>> Delete(int groupId)
        {
            if (groupId <= 0) return BadRequest("request is not valid");

            var success = await _group.DeleteGroupAsync(groupId);

            if (success)
                return Ok("group deleted successfully");
            else return StatusCode(500);
        }

        [HttpGet("search-groups")]
        public async Task<ActionResult<string>> SearchGroups(GroupSearchModel searchModel)
        {
            var teachers = await _group.SearchGroupsAsync(searchModel);

            return JsonConvert.SerializeObject(teachers);
        }

        [HttpPost("add-student-to-group")]
        public async Task<ActionResult<string>> AddStudentToGroup(int groupId, int studentId)
        {
            var success = await _group.AddStudentToGroup(groupId, studentId);

            if (success) return Ok("student added successfully to group");
            else return StatusCode(500);
        }

        [HttpDelete("remove-student-to-group")]
        public async Task<ActionResult<string>> RemoveStudentToGroup(int groupId, int studentId)
        {
            var success = await _group.RemoveStudentToGroup(groupId, studentId);

            if (success) return Ok("student removed successfully to group");
            else return StatusCode(500);
        }

        [HttpPost("add-teacher-to-group")]
        public async Task<ActionResult<string>> AddTeacherToGroup(int groupId, int teacherId)
        {
            var success = await _group.AddTeacherToGroup(groupId, teacherId);

            if (success) return Ok("teacher added successfully to group");
            else return StatusCode(500);
        }

        [HttpDelete("remove-teacher-to-group")]
        public async Task<ActionResult<string>> RemoveTeacherToGroup(int groupId)
        {
            var success = await _group.RemoveTeacherToGroup(groupId);

            if (success) return Ok("teacher removed successfully to group");
            else return StatusCode(500);
        }
        #endregion
    }
}
