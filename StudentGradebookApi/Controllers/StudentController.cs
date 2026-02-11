using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentGradebookApi.DTOs.Students;
using StudentGradebookApi.Models;
using StudentGradebookApi.Services.StudentServices;

namespace StudentGradebookApi.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<StudentList>>> GetStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            var response = _mapper.Map<IEnumerable<StudentList>>(students);
            return Ok(response);
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
                return BadRequest(new { message = "User Already Exists" });
            }
            return Ok();
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult> EditStudent(EditStudent studentData, int id)
        {
            var response = await _studentService.EditStudentAsync(studentData, id);
            if (response == null) return BadRequest(new { message = "Invalid First Name or Last Name" });

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            var response = await _studentService.DeleteStudentAsync(id);
            if(response == null)
            {
                return BadRequest(new {message = "User not found"});
            }
            return Ok();
        }
    }
}
