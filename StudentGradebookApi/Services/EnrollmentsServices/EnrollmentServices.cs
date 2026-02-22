using StudentGradebookApi.DTOs.Enrollments;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.ClassSubjectsRepository;
using StudentGradebookApi.Repositories.EnrollmentsRepository;
using StudentGradebookApi.Repositories.StudentsRepository;
using StudentGradebookApi.Shared;

namespace StudentGradebookApi.Services.EnrollmentsServices
{
    public class EnrollmentServices : IEnrollmentServices
    {
        private readonly IEnrollmentsRepository _enrollmentsRepository;
        private readonly IStudentsRepository _studentsRepository;
        private readonly IClassSubjectsRepository _classSubjectRepository;
        public EnrollmentServices(IEnrollmentsRepository enrollmentsRepository, IStudentsRepository studentsRepository, IClassSubjectsRepository classSubjectRepository) {
            _enrollmentsRepository = enrollmentsRepository;
            _studentsRepository = studentsRepository;
            _classSubjectRepository = classSubjectRepository;
        }

        public async Task<Result> EnrollStudent(int classSubjectId, string studentEmail)
        {
            Students student = await _studentsRepository.GetStudentByEmail(studentEmail);
            if (student == null) return Result.Failure(Errors.StudentErrors.StudentNotFound);

            ClassSubjects classSubject = await _classSubjectRepository.GetByIdAsync(classSubjectId);
            if (classSubject == null) return Result.Failure(Errors.ClassSubjectErrors.ClassSubjectNotFound);

            Enrollments enrollment = new Enrollments();
            enrollment.Status = "Enrolled";
            enrollment.StudentID = student.Id;
            enrollment.ClassSubjectId = classSubjectId;

            await _enrollmentsRepository.AddAsync(enrollment);
            await _enrollmentsRepository.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<Result<IEnumerable<StudentEnrollments>>> GetStudentEnrollments(int studentId)
        {
            return Result<IEnumerable<StudentEnrollments>>.Success(await _enrollmentsRepository.GetStudentEnrollmentsAsync(studentId));
        }


    }
}
