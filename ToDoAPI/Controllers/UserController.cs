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
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        //will need to add more services (teachers, classes etc).
        private readonly IMapper _mapper;
        public UserController(IConfiguration configuration, IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        // GET: api/Students
        /*[HttpGet("students")]
        public async Task<ActionResult<IEnumerable<Students>>> GetStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            var respones = _mapper.Map<List<StudentList>>(students);
            return Ok(respones);
        }*/
        /*[HttpGet("students/{id}")]
        public async Task<ActionResult<IEnumerable<Students>>> GetStudent(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            StudentList response = _mapper.Map<StudentList>(student);
            return Ok(response);
        }*/
        /*[HttpDelete]
        public async Task<ActionResult<IEnumerable<Students>>> DeleteStudent(Students student)
        {
            await _studentService.DeleteStudentAsync(student);
            return Ok();
        }    */  
        //Register user
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser (LoginDTO loginDto)
        {
            var user = await _userService.RegisterAsync(loginDto);
            if (user == null)
            {
                return BadRequest("User already exists.");
            }
            return Ok();
        }
        //Login user
        [HttpPost("login")]
        public async Task<ActionResult<TokenResponse>> LoginUser (LoginDTO loginDto)
        {
            var response = await _userService.LoginAsync(loginDto);
            if (response is null)
            {
                return BadRequest("Invalid email or password");
            }
            return Ok(response);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponse>> RefreshToken(RefreshTokenRequest request)
        {
            var result = await _userService.RefreshTokensAsync(request);
            if (result is null || result.AccessToken is null || result.RefreshToken is null)
                return Unauthorized("Invalid refresh token.");
            return Ok(result);
        }
        /*[Authorize(Roles ="Admin")]
          [HttpGet("admin-only")]
          public IActionResult AdminOnlyOnlyEndpoint()
          {
              return Ok("You are admin!");
          }*/
    }
}
