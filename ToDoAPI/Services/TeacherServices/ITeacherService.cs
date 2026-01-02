using ToDoAPI.DTOs.Students;
using ToDoAPI.Models;

namespace ToDoAPI.Services.TeacherServices
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teachers?>> GetTeachersAsync();
        Task<Teachers?> GetTeacherById(int id);
        Task<Teachers?> EditTeacherById(Teachers teacher,int id);
        Task<Teachers?> AddNewTeacher(Teachers teacher);
        Task DeleteTeacher(int id);
    }
}
