using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Models;
using ToDoAPI.Services;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : Controller
    {
        private readonly IStudentService _studentService;
        //will need to add more services (teachers, classes etc).

        public SchoolController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Students>>> GetStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Students>>> GetStudent(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            return Ok(student);
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<Students>>> DeleteStudent(Students student)
        {
            await _studentService.DeleteStudentAsync(student);
            return Ok();
        }
    }
}
