using StudentGradebookApi.DTOs.Enrollments;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.EnrollmentsRepository;
using StudentGradebookApi.Repositories.StudentsRepository;

namespace StudentGradebookApi.Services.EnrollmentsServices
{
    public class EnrollmentServices : IEnrollmentServices
    {
        private readonly IEnrollmentsRepository _enrollmentsRepository;
        private readonly IStudentsRepository _studentsRepository;
        public EnrollmentServices(IEnrollmentsRepository enrollmentsRepository, IStudentsRepository studentsRepository) {
            _enrollmentsRepository = enrollmentsRepository;
            _studentsRepository = studentsRepository;
        }

        public async Task EnrollStudent(int classSubjectId, string studentEmail)
        {
            Students getStudent = await _studentsRepository.GetStudentByEmail(studentEmail);


            Enrollments newEnrollment = new Enrollments();
            newEnrollment.Status = "Enrolled";
            newEnrollment.StudentID = getStudent.Id;
            newEnrollment.ClassSubjectId = classSubjectId;
            await _enrollmentsRepository.AddAsync(newEnrollment);
            await _enrollmentsRepository.SaveChangesAsync();
            return;
        }

        public async Task<IEnumerable<StudentEnrollments>> GetStudentEnrollments(int studentId)
        {
            var studentEnrollments = await _enrollmentsRepository.GetStudentEnrollmentsAsync(studentId);

            return studentEnrollments;
        }


    }
}
