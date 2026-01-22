using Microsoft.AspNetCore.Mvc;
using StudentGradebookApi.DTOs.ClassSubjects;
using StudentGradebookApi.DTOs.SubjectClass;
using StudentGradebookApi.Models;
using StudentGradebookApi.Services.SubjectClassServices;

namespace StudentGradebookApi.Controllers
{
    [Route("api/class-subjects")]
    [ApiController]
    public class ClassSubjectsController : ControllerBase
    {
        private readonly IClassSubjectsService _classSubjectsService;
        public ClassSubjectsController(IClassSubjectsService classSubjectsService)
        {
            _classSubjectsService = classSubjectsService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassSubjectDTO>>> GetAllClassSubjects()
        {
            var response = await _classSubjectsService.GetAllClassSubjectsAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassSubjects>> GetClassSubjectById(int id)
        {
            var response = await _classSubjectsService.GetClassSubjectsByIdAsync(id);
            return Ok(response);
        }

        [HttpPatch]
        public async Task<ActionResult<CombineClassSubjectDTO>> EditClassSubjectTeacher(CombineClassSubjectDTO combineClassSubjectDTO)
        {
            var response = await _classSubjectsService.AssignSubjectToClassAsync(combineClassSubjectDTO);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ClassSubjectDTO>> CreateNewClassSubject(ClassSubjectDTO newClassSubject)
        {
            ClassSubjectDTO response = await _classSubjectsService.CreateNewClassSubjectAsync(newClassSubject);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClassSubject(int id)
        {
            var response = await _classSubjectsService.RemoveSubjectClassAsync(id);
            return Ok();
        }
    }
}
