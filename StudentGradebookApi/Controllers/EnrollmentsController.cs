using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentGradebookApi.DTOs.Enrollments;
using StudentGradebookApi.Models;
using StudentGradebookApi.Services.EnrollmentsServices;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentGradebookApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentServices _enrollmentServices;
        public EnrollmentsController(IEnrollmentServices enrollmentServices) {
            _enrollmentServices = enrollmentServices;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentEnrollments>>> GetStudentEnrollments()
        {
            int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var response = await _enrollmentServices.GetStudentEnrollments(userId);
            return Ok(response);
        }

        [HttpPost("{classSubjectId}")]
        public async Task<ActionResult<Enrollments>> EnrollStudent(int classSubjectId)
        {
            var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;
            await _enrollmentServices.EnrollStudent(classSubjectId, userEmail);
            return Ok();
        }
    }
}
