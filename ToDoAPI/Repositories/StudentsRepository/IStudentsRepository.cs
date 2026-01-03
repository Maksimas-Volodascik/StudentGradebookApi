using ToDoAPI.DTOs.Students;
using ToDoAPI.Models;
using ToDoAPI.Repositories.Main;

namespace ToDoAPI.Repositories.StudentsRepository
{
    public interface IStudentsRepository : IRepositoryBase<Students>
    {
        Task<IEnumerable<StudentEnrolledSubject>> GetStudentEnrolledSubjects();
    }
}
