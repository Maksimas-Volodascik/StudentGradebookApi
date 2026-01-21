using StudentGradebookApi.DTOs.Subjects;
using StudentGradebookApi.Models;

namespace StudentGradebookApi.Services.SubjectsService
{
    public interface ISubjectsService
    {
        Task<Subjects> AddSubjectAsync(SujectContentsDTO sujectContentsDTO);
        Task<Subjects> UpdateSubjectAsync(int id, SujectContentsDTO sujectContentsDTO);
        Task<Subjects?> GetSubjectByIdAsync(int id);
        Task<IEnumerable<Subjects>> GetAllSubjectsAsync();
        Task<Subjects?> DeleteSubjectAsync(int id);
    }
}
