using StudentGradebookApi.DTOs.Students;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.Main;

namespace StudentGradebookApi.Services.StudentServices
{
    public interface IStudentService
    {
        Task<IEnumerable<Students>> GetAllStudentsAsync();
        Task<Students?> GetStudentByIdAsync(int id);
        Task<Students?> AddStudentAsync(NewStudent studentData);
        Task<Students?> EditStudentAsync(EditStudent studentData, int id);
    }
}
