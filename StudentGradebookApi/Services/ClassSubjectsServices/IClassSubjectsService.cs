using StudentGradebookApi.DTOs.SubjectClass;
using StudentGradebookApi.Models;

namespace StudentGradebookApi.Services.SubjectClassServices
{
    public interface IClassSubjectsService
    {
        Task<NewClassSubject> AddClassesAsync(NewClassSubject classSubjects);
    }
}
