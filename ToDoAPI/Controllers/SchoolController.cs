using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.DTOs;
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
        private readonly IMapper _mapper;
        private readonly TokenService _tokenService;
        public SchoolController(IStudentService studentService, IMapper mapper, TokenService tokenService)
        {
            _studentService = studentService;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        // POST: api/auth/login
        [HttpPost("login")]
        public async Task<ActionResult<IEnumerable<Students>>> GetStudents()
        {

        }


        // GET: api/Students
        [HttpGet("students")]
        public async Task<ActionResult<IEnumerable<Students>>> GetStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }
        [HttpGet("students/{id}")]
        public async Task<ActionResult<IEnumerable<Students>>> GetStudent(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            StudentData response = _mapper.Map<StudentData>(student);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<IEnumerable<Students>>> DeleteStudent(Students student)
        {
            await _studentService.DeleteStudentAsync(student);
            return Ok();
        }
    }
}
