using Moq;
using StudentGradebookApi.DTOs.Subjects;
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
    public class UpdateSubjectAsyncTests
    {
        private readonly Mock<ISubjectsRepository> _mockRepository;
        private readonly SubjectsService _subjectsService;

        public UpdateSubjectAsyncTests()
        {
            _mockRepository = new Mock<ISubjectsRepository>();
            _subjectsService = new SubjectsService(_mockRepository.Object);
        }

        [Fact]
        public async Task UpdateSubjectAsync_ValidData_ReturnsSuccessResult()
        {
            var subject = new Subjects();

            var dto = new SujectContentsDTO
            {
                subjectName = "Math",
                subjectCode = "Math101",
                description = "Description about math"
            };

            _mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                   .ReturnsAsync(subject);

            var result = await _subjectsService.UpdateSubjectAsync(1, dto);

            Assert.True(result.IsSuccess);
            _mockRepository.Verify(r => r.Update(subject), Times.Once);
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateSubjectAsync_InvalidData_ReturnsFailureResult()
        {
            var dto = new SujectContentsDTO
            {
                subjectName = "",
                subjectCode = "",
                description = "Description about math"
            };

            var result = await _subjectsService.UpdateSubjectAsync(1, dto);

            Assert.False(result.IsSuccess);
            _mockRepository.Verify(r => r.Update(It.IsAny<Subjects>()), Times.Never);
        }

        [Fact]
        public async Task UpdateSubjectAsync_SubjectNotFound_ReturnsFailureResult()
        {
            var dto = new SujectContentsDTO
            {
                subjectName = "Math",
                subjectCode = "Math101",
                description = "Description about math"
            };

            _mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>()))
                   .ReturnsAsync((Subjects)null);

            var result = await _subjectsService.UpdateSubjectAsync(1, dto);

            Assert.False(result.IsSuccess);
        }
    }
}
