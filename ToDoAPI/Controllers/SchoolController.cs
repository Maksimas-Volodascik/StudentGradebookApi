using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
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
        public SchoolController(IConfiguration configuration, IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
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
        //Register user
        [HttpPost("register")]
        public async Task<ActionResult<IEnumerable<Students>>> RegisterStudent (StudentData studentData)
        {
            var student = await _studentService.RegisterAsync(studentData);
            if (student == null)
            {
                return BadRequest("User already exists.");
            }
            return Ok(student);
        }
        //Login user
        [HttpPost("login")]
        public async Task<ActionResult<string>> LoginStudent (StudentData studentData)
        {
            var token = await _studentService.LoginAsync(studentData);
            if (token is null)
            {
                return BadRequest("Invalid email or password");
            }
            return Ok(token);
        }

        [Authorize]
        [HttpGet("Auth")]
        public IActionResult AuthenticatedOnlyEndpoint()
        {
            return Ok("You are authenticated!");
        }
    }
}
