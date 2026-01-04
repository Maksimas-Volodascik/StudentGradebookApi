using ToDoAPI.DTOs.Students;
using ToDoAPI.DTOs.Teachers;
using ToDoAPI.Models;

namespace ToDoAPI.Services.TeacherServices
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teachers>> GetAllTeachersAsync();
        Task<Teachers?> GetTeacherByIdAsync(int id);
        Task<Teachers?> AddTeacherAsync(NewTeacherDTO teacherData);
        Task<Teachers?> EditTeacherAsync(TeacherDTO teacher);
        Task DeleteTeacherAsync(int id);
    }
}
