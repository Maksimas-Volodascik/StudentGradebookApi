using StudentGradebookApi.Models;

namespace StudentGradebookApi.Services.SubjectsService
{
    public interface ISubjectsService
    {
        Task<Subjects> AddSubjectAsync(string subjectName, string subjectCode, string description);
        Task<Subjects> UpdateSubjectAsync(int id, string subjectName, string subjectCode, string description);
        Task<Subjects?> GetSubjectByIdAsync(int id);
        Task<IEnumerable<Subjects>> GetAllSubjectsAsync();
        Task<Subjects?> DeleteSubjectAsync(int id);
    }
}
