using Moq;
using StudentGradebookApi.DTOs.Teachers;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.TeachersRepository;
using StudentGradebookApi.Services.SubjectClassServices;
using StudentGradebookApi.Services.TeacherServices;
using StudentGradebookApi.Services.UserServices;
using StudentGradebookApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradebookApi.Tests.Services.Teacher
{
    public class DeleteTeacherAsyncTests
    {
        private readonly TeacherService _teacherService;
        private readonly Mock<ITeachersRepository> _teacherRepMock;
        private readonly Mock<IUserService> _userServiceMock;

        public DeleteTeacherAsyncTests()
        {
            _teacherRepMock = new Mock<ITeachersRepository>();
            _userServiceMock = new Mock<IUserService>();

            _teacherService = new TeacherService(_teacherRepMock.Object, _userServiceMock.Object);
        }

        [Fact]
        public async Task DeleteTeacherAsync_TeacherExistsAndUserDeleted_ReturnsSuccess()
        {
            var teacher = new Teachers { Id = 1, UserID = 2};

            _teacherRepMock.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(teacher);

            _userServiceMock.Setup(u => u.DeleteUserAsync(2))
                .ReturnsAsync(Result.Success());

            var result = await _teacherService.DeleteTeacherAsync(1);

            Assert.True(result.IsSuccess);
            Assert.Null(result.Error);
            _teacherRepMock.Verify(r => r.GetByIdAsync(1), Times.Once);
            _userServiceMock.Verify(u => u.DeleteUserAsync(2), Times.Once);
        }

        [Fact]
        public async Task DeleteTeacherAsync_TeacherNotFound_ReturnsFailure()
        {
            _teacherRepMock.Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync((Teachers)null); 

            var result = await _teacherService.DeleteTeacherAsync(1);

            Assert.False(result.IsSuccess);
            Assert.Equal(Errors.TeacherErrors.TeacherNotFound, result.Error);
            _teacherRepMock.Verify(r => r.GetByIdAsync(1), Times.Once);
            _userServiceMock.VerifyNoOtherCalls();
        }
    }
}
