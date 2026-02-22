using StudentGradebookApi.DTOs.Subjects;
using StudentGradebookApi.Models;
using StudentGradebookApi.Shared;

namespace StudentGradebookApi.Services.SubjectsService
{
    public interface ISubjectsService
    {
        Task<Result> AddSubjectAsync(SujectContentsDTO sujectContentsDTO);
        Task<Result> UpdateSubjectAsync(int id, SujectContentsDTO sujectContentsDTO);
        Task<Result<Subjects>> GetSubjectByIdAsync(int id);
        Task<Result<IEnumerable<Subjects>>> GetAllSubjectsAsync();
        Task<Result> DeleteSubjectAsync(int id);
    }
}
