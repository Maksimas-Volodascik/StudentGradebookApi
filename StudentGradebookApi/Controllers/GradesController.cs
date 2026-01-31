using Microsoft.AspNetCore.Mvc;
using StudentGradebookApi.DTOs.Grades;
using StudentGradebookApi.Services.GradesServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentGradebookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IGradesServices _gradesService;
        public GradesController(IGradesServices gradesServices) { 
            _gradesService = gradesServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentGradesBySubjectDTO>>> GetStudentGradesBySubject()
        {
            var studentGrades = await _gradesService.GetStudentGradesByStudentId();
            return Ok(studentGrades);
        }
    }
}
