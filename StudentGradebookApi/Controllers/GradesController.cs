using Microsoft.AspNetCore.Mvc;
using StudentGradebookApi.DTOs.Grades;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.GradesRepository;
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
        public async Task<ActionResult<IEnumerable<StudentGradesBySubjectDTO>>> GetStudentGradesBySubject(int year, int month)
        {
            var studentGrades = await _gradesService.GetStudentGradesBySubjectId(year, month);
            return Ok(studentGrades);
        }

        [HttpPost]
        public async Task<ActionResult<NewGradeDTO>> NewGrade(byte score, string gradeType, string gradingDate, int enrollmentId)
        {
            DateTime receivedDate = DateTime.Parse(gradingDate);
            await _gradesService.AddGrade(score, gradeType, receivedDate, enrollmentId);
            return Ok();
        }
    }
}
