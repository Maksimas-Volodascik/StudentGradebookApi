using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.Models;

namespace ToDoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : Controller
    {
        private readonly SchoolDbContext _context;

        public SchoolController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Students>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }
    }
}
