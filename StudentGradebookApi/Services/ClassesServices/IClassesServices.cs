using StudentGradebookApi.DTOs.Classes;
using StudentGradebookApi.Models;

namespace StudentGradebookApi.Services.ClassesServices
{
    public interface IClassesServices
    {
        Task<Classes> AddClassAsync(ClassesContentsDTO classesContentsDTO);
        Task<Classes?> UpdateClassAsync(int id, ClassesContentsDTO classesContentsDTO);
        Task<Classes?> GetClassByIdAsync(int id);
        Task<IEnumerable<Classes?>> GetAllClassesAsync();
        Task<IEnumerable<Classes?>> GetClassesByYearAsync(string academicYear);
    }
}
