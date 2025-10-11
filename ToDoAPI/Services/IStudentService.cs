using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Students>> GetAllStudentsAsync();
        Task<Students?> GetStudentByIdAsync(int id);
        Task AddStudentAsync(Students student);
    }
}
