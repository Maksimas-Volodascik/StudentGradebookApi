using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoAPI.DTOs.Students;
using ToDoAPI.Models;
using ToDoAPI.Services.StudentServices;

namespace ToDoAPI.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentController(IConfiguration configuration, IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<StudentList>>> GetStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            var respones = _mapper.Map<List<StudentList>>(students);
            return Ok(respones);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<StudentList>>> GetStudent(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            StudentList response = _mapper.Map<StudentList>(student);
            return Ok(response);
        }

        [HttpPost()]
        public async Task<ActionResult<IEnumerable<Students>>> AddStudent(NewStudent studentData)
        {
            var response = await _studentService.AddStudentAsync(studentData);
            if(response == null)
            {
                return BadRequest("User Already Exists");
            }
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            await _studentService.DeleteStudentAsync(student);
            return Ok();
        }   
    }
}
