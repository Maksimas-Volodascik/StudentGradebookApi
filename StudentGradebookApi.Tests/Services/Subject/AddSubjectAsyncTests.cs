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
    public class AddSubjectAsyncTests
    {
        private readonly Mock<ISubjectsRepository> _mockRepository;
        private readonly SubjectsService _subjectsService;

        public AddSubjectAsyncTests() {
            _mockRepository = new Mock<ISubjectsRepository>();
            _subjectsService = new SubjectsService(_mockRepository.Object);
        }

        [Fact] 
        public async Task AddSubjectAsync_ValidData_ReturnsSuccessResult()
        {
            var dto = new SubjectContentsDTO
            {
                subjectName = "Math",
                subjectCode = "Math101",
                description = "Description about math"
            };

            var result = await _subjectsService.AddSubjectAsync(dto);

            Assert.True(result.IsSuccess);
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<Subjects>()), Times.Once);
            _mockRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task AddSubjectAsync_InvalidData_ReturnsFailureResult()
        {
            var dto = new SubjectContentsDTO
            {
                subjectName = "Math",
                subjectCode = "",
                description = "Description about math"
            };

            var result = await _subjectsService.AddSubjectAsync(dto);

            Assert.False(result.IsSuccess);
            _mockRepository.Verify(r => r.AddAsync(It.IsAny<Subjects>()), Times.Never);
        }
    }
}
