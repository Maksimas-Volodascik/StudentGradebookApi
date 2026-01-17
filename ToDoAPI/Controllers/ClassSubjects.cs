using Microsoft.AspNetCore.Mvc;
using ToDoAPI.DTOs.SubjectClass;
using ToDoAPI.Services.SubjectClassServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoAPI.Controllers
{
    [Route("api/classes")]
    [ApiController]
    public class ClassSubjects : ControllerBase
    {
        private readonly IClassSubjectsService _subjectService;
        public ClassSubjects(IClassSubjectsService subjectService) { 
            _subjectService = subjectService;
        }

        [HttpPost]
        public async Task<ActionResult> NewSubject(NewClassSubject newClassSubject)
        {
            await _subjectService.AddClassesAsync(newClassSubject);
            return Ok(newClassSubject);
        }


    }
}
