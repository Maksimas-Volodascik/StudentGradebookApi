using Moq;
using StudentGradebookApi.Repositories.StudentsRepository;
using StudentGradebookApi.Services.StudentServices;
using StudentGradebookApi.Services.UserServices;

namespace StudentGradebookApi.Tests.Services
{
    public class StudentServiceTest
    {
        [Fact] 
        public async Task GetStudentByIdAsync_StudentExists_ReturnsStudent() { 
            var mockRepo = new Mock<IStudentsRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(1))
                .ReturnsAsync(new Models.Students
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = DateTimeOffset.Parse("2000-01-01"),
                    EnrollmentDate = DateTimeOffset.Parse("2023-09-01"),
                    Status = "Enrolled",
                    Enrollments = new List<Models.Enrollments>(),
                    UserID = 10,
                    User = new Models.WebUsers()
                });
                var userService = new Mock<IUserService>(); 
            var service = new StudentService(userService.Object, mockRepo.Object); 
            var result = await service.GetStudentByIdAsync(1);

            Assert.Equal(1, result.Id);
            Assert.Equal("John", result.FirstName);
            Assert.Equal("Doe", result.LastName);
        }

        [Fact]
        public async Task GetStudentByIdAsync_StudentDoesNotExist_ReturnsNull()
        {

            var mockRepo = new Mock<IStudentsRepository>();
            mockRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                    .ReturnsAsync((Models.Students?)null);

            var userService = new Mock<IUserService>();
            var service = new StudentService(userService.Object, mockRepo.Object);

            var result = await service.GetStudentByIdAsync(-1);

            Assert.Null(result);
        }
    }
}
