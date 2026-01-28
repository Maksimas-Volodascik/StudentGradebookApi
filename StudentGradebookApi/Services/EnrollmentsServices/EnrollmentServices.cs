using StudentGradebookApi.DTOs.Enrollments;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.EnrollmentsRepository;

namespace StudentGradebookApi.Services.EnrollmentsServices
{
    public class EnrollmentServices : IEnrollmentServices
    {
        private readonly IEnrollmentsRepository _enrollmentsRepository;
        public EnrollmentServices(IEnrollmentsRepository enrollmentsRepository) {
            _enrollmentsRepository = enrollmentsRepository;
        }

        public async Task<IEnumerable<StudentEnrollments>> GetStudentEnrollments(int id)
        {
            var studentEnrollments = await _enrollmentsRepository.GetStudentEnrollmentsAsync(id);

            return studentEnrollments;
        }
    }
}
