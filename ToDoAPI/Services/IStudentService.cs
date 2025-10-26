using ToDoAPI.DTOs;
using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Students>> GetAllStudentsAsync();
        Task<Students?> GetStudentByIdAsync(int id);
        Task DeleteStudentAsync(Students student);
        Task<Students?> RegisterAsync(StudentData request);
        Task<string?> LoginAsync(StudentData request);
    }
}
