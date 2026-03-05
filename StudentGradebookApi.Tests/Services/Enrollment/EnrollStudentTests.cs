using Moq;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.EnrollmentsRepository;
using StudentGradebookApi.Services.EnrollmentsServices;
using StudentGradebookApi.Services.StudentServices;
using StudentGradebookApi.Services.SubjectClassServices;
using StudentGradebookApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradebookApi.Tests.Services.Enrollment
{
    public class EnrollStudentTests
    {
        private readonly Mock<IEnrollmentsRepository> _enrollmentsRepositoryMock;
        private readonly Mock<IStudentService> _studentServiceMock;
        private readonly Mock<IClassSubjectsService> _classSubjectsServiceMock;
        private readonly EnrollmentServices _enrollmentServices;

        public EnrollStudentTests()
        {
            _enrollmentsRepositoryMock = new Mock<IEnrollmentsRepository>();
            _studentServiceMock = new Mock<IStudentService>();
            _classSubjectsServiceMock = new Mock<IClassSubjectsService>();

            _enrollmentServices = new EnrollmentServices(_enrollmentsRepositoryMock.Object, _studentServiceMock.Object, _classSubjectsServiceMock.Object);
        }

        [Fact]
        public async Task EnrollStudent_ValidData_ReturnsSuccessResult()
        {
            var student = new Students { Id = 1 };
            var classSubject = new ClassSubjects { Id = 10 };
            Enrollments enrollment = new Enrollments();

            _studentServiceMock.Setup(x => x.GetStudentByEmailAsync("test@test.com"))
                .ReturnsAsync(Result<Students>.Success(student));

            _classSubjectsServiceMock.Setup(x => x.GetClassSubjectsByIdAsync(1))
                .ReturnsAsync(Result<ClassSubjects>.Success(classSubject));

            var result = await _enrollmentServices.EnrollStudent(1, "test@test.com");

            Assert.True(result.IsSuccess);
            _enrollmentsRepositoryMock.Verify(x => x.AddAsync(It.Is<Enrollments>(e =>
                e.StudentID == student.Id &&
                e.ClassSubjectId == classSubject.Id &&
                e.Status == "Enrolled"
            )), Times.Once);
            _enrollmentsRepositoryMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task EnrollStudent_InvalidData_ReturnsStudentNotFound()
        {
            _studentServiceMock.Setup(x => x.GetStudentByEmailAsync("test@test.com"))
                .ReturnsAsync(Result<Students>.Failure(Errors.StudentErrors.StudentNotFound));

            var result = await _enrollmentServices.EnrollStudent(1, "test@test.com");

            Assert.False(result.IsSuccess);
            _enrollmentsRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Enrollments>()), Times.Never);
            _enrollmentsRepositoryMock.Verify(x => x.SaveChangesAsync(), Times.Never);
        }

        [Fact]
        public async Task EnrollStudent_InvalidData_ReturnsClassSubjectNotFound()
        {
            var student = new Students { Id = 1 };

            _studentServiceMock.Setup(x => x.GetStudentByEmailAsync("test@test.com"))
                .ReturnsAsync(Result<Students>.Success(student));
            
            _classSubjectsServiceMock.Setup(x => x.GetClassSubjectsByIdAsync(1))
                .ReturnsAsync(Result<ClassSubjects>.Failure(Errors.ClassSubjectErrors.ClassSubjectNotFound));

            var result = await _enrollmentServices.EnrollStudent(1, "test@test.com");

            Assert.False(result.IsSuccess);
            _enrollmentsRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Enrollments>()), Times.Never);
            _enrollmentsRepositoryMock.Verify(x => x.SaveChangesAsync(), Times.Never);
        }
    }
}
