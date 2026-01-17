using StudentGradebookApi.DTOs.Students;
using StudentGradebookApi.DTOs.Teachers;
using StudentGradebookApi.Models;

namespace StudentGradebookApi.Services.TeacherServices
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teachers>> GetAllTeachersAsync();
        Task<Teachers?> GetTeacherByIdAsync(int id);
        Task<Teachers?> AddTeacherAsync(NewTeacherDTO teacherData);
        Task<Teachers?> EditTeacherAsync(TeacherDTO teacher);
    }
}
