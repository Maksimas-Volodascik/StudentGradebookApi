using StudentGradebookApi.DTOs.Enrollments;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.Main;

namespace StudentGradebookApi.Repositories.EnrollmentsRepository
{
    public interface IEnrollmentsRepository : IRepositoryBase<Enrollments>
    {
        Task<IEnumerable<StudentEnrollments>> GetStudentEnrollmentsAsync(int id);
    }
}
