using ToDoAPI.DTOs.Students;
using ToDoAPI.Models;

namespace ToDoAPI.Services.StudentServices
{
    public interface IStudentService
    {
        Task<IEnumerable<Students>> GetAllStudentsAsync();
        Task<Students?> GetStudentByIdAsync(int id);
        Task<Students?> AddStudentAsync(NewStudent studentData);
        Task DeleteStudentAsync(Students student);
    }
}
