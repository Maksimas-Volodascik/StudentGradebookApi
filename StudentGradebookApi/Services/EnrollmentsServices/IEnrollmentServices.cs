using StudentGradebookApi.DTOs.Enrollments;
using StudentGradebookApi.Models;
using StudentGradebookApi.Shared;

namespace StudentGradebookApi.Services.EnrollmentsServices
{
    public interface IEnrollmentServices
    {
        Task<Result<IEnumerable<StudentEnrollments>>> GetStudentEnrollments(int studentId);

        Task<Result> EnrollStudent(int classSubjectId, string studentEmail);
    }
}
