using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentGradebookApi.DTOs.Enrollments;
using StudentGradebookApi.Services.EnrollmentsServices;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentGradebookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly IEnrollmentServices _enrollmentServices;
        public EnrollmentsController(IEnrollmentServices enrollmentServices) {
            _enrollmentServices = enrollmentServices;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentEnrollments>>> GetData()
        {
            int userId = Int32.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var response = await _enrollmentServices.GetStudentEnrollments(userId);
            return Ok(response);
        }

    }
}
