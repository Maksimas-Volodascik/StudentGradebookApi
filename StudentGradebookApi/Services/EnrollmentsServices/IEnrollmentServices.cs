using StudentGradebookApi.DTOs.Enrollments;
using StudentGradebookApi.Models;

namespace StudentGradebookApi.Services.EnrollmentsServices
{
    public interface IEnrollmentServices
    {
        Task<IEnumerable<StudentEnrollments>> GetStudentEnrollments(int studentId);

        Task EnrollStudent(int classSubjectId, string studentEmail);
    }
}
