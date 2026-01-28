using StudentGradebookApi.DTOs.Enrollments;
using StudentGradebookApi.Models;

namespace StudentGradebookApi.Services.EnrollmentsServices
{
    public interface IEnrollmentServices
    {
        Task<IEnumerable<StudentEnrollments>> GetStudentEnrollments(int id);
    }
}
