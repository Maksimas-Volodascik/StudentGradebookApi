using Moq;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.ClassSubjectsRepository;
using StudentGradebookApi.Services.ClassesServices;
using StudentGradebookApi.Services.SubjectClassServices;
using StudentGradebookApi.Services.SubjectsService;
using StudentGradebookApi.Services.TeacherServices;
using StudentGradebookApi.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGradebookApi.Tests.Services.ClassSubject
{
    public class EditSubjectClassTeacher
    {
        private readonly Mock<IClassSubjectsRepository> _classSubjectsRepositoryMock;
        private readonly Mock<ITeacherService> _teacherService;
        private readonly Mock<ISubjectsService> _subjectsService;
        private readonly Mock<IClassesServices> _classesService;
        private readonly ClassSubjectsService _classSubjectsService;

        public EditSubjectClassTeacher()
        {
            _classSubjectsRepositoryMock = new Mock<IClassSubjectsRepository>();
            _teacherService = new Mock<ITeacherService>();
            _subjectsService = new Mock<ISubjectsService>();
            _classesService = new Mock<IClassesServices>();

            _classSubjectsService = new ClassSubjectsService(_classSubjectsRepositoryMock.Object, _teacherService.Object, _subjectsService.Object, _classesService.Object);
        }

        [Fact]
        public async Task EditSubjectClassTeacher_ValidData_ReturnsSuccess()
        {
            int teacherId = 1;
            int classSubjectId = 10;
            var teacher = new Teachers { Id = teacherId };
            var classSubject = new ClassSubjects { Id = classSubjectId };

            _teacherService.Setup(x => x.GetTeacherByIdAsync(teacherId))
                .ReturnsAsync(Result<Teachers>.Success(teacher));

            _classSubjectsRepositoryMock.Setup(x => x.GetByIdAsync(classSubjectId))
                .ReturnsAsync(classSubject);

            var result = await _classSubjectsService.EditSubjectClassTeacher(classSubjectId, teacherId);

            Assert.True(result.IsSuccess);
            _classSubjectsRepositoryMock.Verify(r => r.Update(It.Is<ClassSubjects>(cs =>
                    cs.TeacherId == teacherId && cs.Teachers == teacher)), Times.Once);
            _classSubjectsRepositoryMock.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task EditSubjectClassTeacher_TeacherNotFound_ReturnsFailure()
        {
            int teacherId = 1;
            int classSubjectId = 10;
            var error = Errors.TeacherErrors.TeacherNotFound;

            _teacherService.Setup(x => x.GetTeacherByIdAsync(teacherId))
                .ReturnsAsync(Result<Teachers>.Failure(error));

            var result = await _classSubjectsService.EditSubjectClassTeacher(classSubjectId, teacherId);

            Assert.False(result.IsSuccess);
            Assert.Equal(error, result.Error);
            _classSubjectsRepositoryMock.Verify(r => r.Update(It.IsAny<ClassSubjects>()), Times.Never);
            _classSubjectsRepositoryMock.Verify(r => r.SaveChangesAsync(), Times.Never);
        }

        [Fact]
        public async Task EditSubjectClassTeacher_ClassSubjectNotFound_ReturnsFailure()
        {
            int teacherId = 1;
            int classSubjectId = 10;
            var teacher = new Teachers { Id = teacherId };
            var error = Errors.ClassSubjectErrors.ClassSubjectNotFound;

            _teacherService.Setup(x => x.GetTeacherByIdAsync(teacherId))
                .ReturnsAsync(Result<Teachers>.Success(teacher));

            _classSubjectsRepositoryMock.Setup(x => x.GetByIdAsync(classSubjectId))
                .ReturnsAsync((ClassSubjects)null);

            var result = await _classSubjectsService.EditSubjectClassTeacher(classSubjectId, teacherId);

            Assert.False(result.IsSuccess);
            Assert.Equal(error, result.Error);
            _classSubjectsRepositoryMock.Verify(r => r.Update(It.IsAny<ClassSubjects>()), Times.Never);
            _classSubjectsRepositoryMock.Verify(r => r.SaveChangesAsync(), Times.Never);
        }
    }
}
