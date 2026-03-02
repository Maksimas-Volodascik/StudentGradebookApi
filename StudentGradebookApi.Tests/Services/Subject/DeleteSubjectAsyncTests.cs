using Moq;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.SubjectsRepository;
using StudentGradebookApi.Services.SubjectsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradebookApi.Tests.Services.Subject
{
    public class DeleteSubjectAsyncTests
    {
        private readonly Mock<ISubjectsRepository> _mockRepository;
        private readonly SubjectsService _subjectsService;

        public DeleteSubjectAsyncTests()
        {
            _mockRepository = new Mock<ISubjectsRepository>();
            _subjectsService = new SubjectsService(_mockRepository.Object);
        }

        [Fact]
        public async Task DeleteSubjectAsync_ValidData_ReturnsSuccessResult()
        {
            var subject = new Subjects { SubjectName = "Test" };

            _mockRepository.Setup(s => s.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(subject);

            var result = await _subjectsService.DeleteSubjectAsync(1);

            Assert.True(result.IsSuccess);
            _mockRepository.Verify(r => r.Delete(subject), Times.Once());
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once());
        }

        [Fact]
        public async Task DeleteSubjectAsync_InvalidData_ReturnsFailureResult()
        {
            var subject = new Subjects { SubjectName = "Test" };

            _mockRepository.Setup(s => s.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync((Subjects)null);

            var result = await _subjectsService.DeleteSubjectAsync(1);

            Assert.False(result.IsSuccess);
            _mockRepository.Verify(r => r.Delete(subject), Times.Never());

        }
    }
}
