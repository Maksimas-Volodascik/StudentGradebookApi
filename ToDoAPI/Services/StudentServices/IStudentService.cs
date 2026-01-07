using ToDoAPI.DTOs.Students;
using ToDoAPI.Models;
using ToDoAPI.Repositories.Main;

namespace ToDoAPI.Services.StudentServices
{
    public interface IStudentService
    {
        Task<IEnumerable<Students>> GetAllStudentsAsync();
        Task<Students?> GetStudentByIdAsync(int id);
        Task<Students?> AddStudentAsync(NewStudent studentData);
        Task<Students?> EditStudentAsync(EditStudent studentData, int id);
    }
}
