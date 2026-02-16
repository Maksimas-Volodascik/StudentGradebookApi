using StudentGradebookApi.DTOs.Students;
using StudentGradebookApi.DTOs.Teachers;
using StudentGradebookApi.Models;

namespace StudentGradebookApi.Services.TeacherServices
{
    public interface ITeacherService
    {
        Task<List<TeacherDTO>> GetAllTeachersAsync();
        Task<Teachers?> GetTeacherByIdAsync(int id);
        Task<Teachers?> AddTeacherAsync(TeacherRequestDTO teacherData);
        Task<Teachers?> EditTeacherAsync(int teacherId, TeacherRequestDTO teacher);
        Task<Teachers?> DeleteTeacherAsync(int id);
    }
}
