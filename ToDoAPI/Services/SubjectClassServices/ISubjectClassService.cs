using ToDoAPI.DTOs.SubjectClass;
using ToDoAPI.Models;

namespace ToDoAPI.Services.SubjectClassServices
{
    public interface ISubjectClassService
    {
        Task<Classes> GetAllClassesAsync();
        Task<Classes> GetClassesAsync();
        Task DeleteClassesAsync(int id);
        Task<Classes> AddClasses(Classes classes);

        Task<Subjects> GetAllSubjectsAsync();
        Task<Subjects> GetSubjectAsync();
        Task DeleteSubjectAsync(int id);
        Task<Subjects> AddSubject(Subjects subjects);

        Task AddClassSubject(NewClassSubject newClassSubject);
        Task<IEnumerable<ClassSubjects>> GetAllClassSubjects();
    }
}
