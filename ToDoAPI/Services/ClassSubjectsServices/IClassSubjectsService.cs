using ToDoAPI.DTOs.SubjectClass;
using ToDoAPI.Models;

namespace ToDoAPI.Services.SubjectClassServices
{
    public interface IClassSubjectsService
    {
        Task<NewClassSubject> AddClassesAsync(NewClassSubject classSubjects);
    }
}
