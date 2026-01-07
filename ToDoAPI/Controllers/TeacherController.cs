using Microsoft.AspNetCore.Mvc;
using ToDoAPI.DTOs.Teachers;
using ToDoAPI.Models;
using ToDoAPI.Services.TeacherServices;

namespace ToDoAPI.Controllers
{
    [Route("api/teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teachers>>> GetTeachers()
        {
            var response = await _teacherService.GetAllTeachersAsync();
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult> AddNewTeacher(NewTeacherDTO newTeacher)
        {
            await _teacherService.AddTeacherAsync(newTeacher);
            return Ok();
        }
    }
}
