using StudentGradebookApi.DTOs.ClassSubjects;
using StudentGradebookApi.DTOs.SubjectClass;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.ClassesRepository;
using StudentGradebookApi.Repositories.ClassSubjectsRepository;
using StudentGradebookApi.Repositories.Main;
using StudentGradebookApi.Repositories.StudentsRepository;
using StudentGradebookApi.Repositories.SubjectsRepository;
using StudentGradebookApi.Repositories.TeachersRepository;
using StudentGradebookApi.Services.UserServices;
using StudentGradebookApi.Shared;
using System.Collections.Generic;

namespace StudentGradebookApi.Services.SubjectClassServices
{
    public class ClassSubjectsService : IClassSubjectsService
    {
        private readonly IClassSubjectsRepository _classSubjectsRepository;
        private readonly ITeachersRepository _teachersRepository;
        private readonly ISubjectsRepository _subjectsRepository;
        private readonly IClassesRepository _classesRepository;
        public ClassSubjectsService(IClassSubjectsRepository classSubjectsRepository, ITeachersRepository teachersRepository, ISubjectsRepository subjectsRepository, IClassesRepository classesRepository)
        {
            _classSubjectsRepository = classSubjectsRepository;
            _teachersRepository = teachersRepository;
            _subjectsRepository = subjectsRepository;
            _classesRepository = classesRepository;
        }

        public async Task<Result> AssignSubjectToClassAsync(CombineClassSubjectDTO combineClassSubjectDTO)
        {
            if (_subjectsRepository.GetByIdAsync(combineClassSubjectDTO.SubjectId) == null || _classesRepository.GetByIdAsync(combineClassSubjectDTO.ClassId) == null)
                return Result.Failure(Errors.ClassSubjectErrors.InvalidClassSubject);

            ClassSubjects classSubjects = new ClassSubjects();
            classSubjects.SubjectId = combineClassSubjectDTO.SubjectId;
            classSubjects.ClassId = combineClassSubjectDTO.ClassId;

            await _classSubjectsRepository.AddAsync(classSubjects);
            await _classSubjectsRepository.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<Result> EditSubjectClassTeacher(int classSubjectsId, int teacherId)
        {
            Teachers? teacher = await _teachersRepository.GetByIdAsync(teacherId);
            ClassSubjects? classSubject = await _classSubjectsRepository.GetByIdAsync(classSubjectsId);

            if (teacher == null)
                return Result.Failure(Errors.TeacherErrors.TeacherNotFound);

            if (classSubject == null)
                return Result.Failure(Errors.ClassSubjectErrors.ClassSubjectNotFound);

            classSubject.Teachers = teacher;
            classSubject.TeacherId = teacherId;

            _classSubjectsRepository.Update(classSubject);
            await _classSubjectsRepository.SaveChangesAsync();

            return Result.Success();
        }

        public async Task<Result<ClassSubjects>> GetClassSubjectsByIdAsync(int classSubjectsId)
        {
            ClassSubjects? classSubject = await _classSubjectsRepository.GetByIdAsync(classSubjectsId);
            if (classSubject == null) return Result<ClassSubjects>.Failure(Errors.ClassSubjectErrors.ClassSubjectNotFound);

            return Result<ClassSubjects>.Success(classSubject);
        }

        public async Task<Result<IEnumerable<ClassSubjectDTO>>> GetAllClassSubjectsAsync()
        {
            return Result<IEnumerable<ClassSubjectDTO>>.Success(await _classSubjectsRepository.GetAllClassSubjectsAsync());
        }

        public async Task<Result> RemoveSubjectClassAsync(int classSubjectsId)
        {
            ClassSubjects? classSubject = await _classSubjectsRepository.GetByIdAsync(classSubjectsId);
            if (classSubject == null) return Result<ClassSubjects>.Failure(Errors.ClassSubjectErrors.ClassSubjectNotFound);

            _classSubjectsRepository.Delete(classSubject);
            await _classSubjectsRepository.SaveChangesAsync();
            
            return Result.Success();
        }
    }
}
