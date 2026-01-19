using StudentGradebookApi.Models;

namespace StudentGradebookApi.Services.ClassesServices
{
    public interface IClassesServices
    {
        Task<Classes> AddClassAsync(string academicYear, int room);
        Task<Classes?> UpdateClassAsync(int id, string academicYear, int room);
        Task<Classes?> GetClassByIdAsync(int id);
        Task<IEnumerable<Classes?>> GetAllClassesAsync();
        Task<IEnumerable<Classes?>> GetClassesByYearAsync(string academicYear);
    }
}
