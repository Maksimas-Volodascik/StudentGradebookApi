using StudentGradebookApi.DTOs.Students;
using StudentGradebookApi.DTOs.Teachers;
using StudentGradebookApi.Models;
using StudentGradebookApi.Shared;

namespace StudentGradebookApi.Services.TeacherServices
{
    public interface ITeacherService
    {
        Task<Result<List<TeacherDTO>>> GetAllTeachersAsync();
        Task<Result<Teachers>> GetTeacherByIdAsync(int id);
        Task<Result<Teachers>> AddTeacherAsync(TeacherRequestDTO teacherData);
        Task<Result<Teachers>> EditTeacherAsync(int teacherId, TeacherRequestDTO teacher);
        Task<Result> DeleteTeacherAsync(int id);
    }
}
