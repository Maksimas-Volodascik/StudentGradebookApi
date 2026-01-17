using StudentGradebookApi.DTOs.SubjectClass;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.ClassesRepository;
using StudentGradebookApi.Repositories.ClassSubjectsRepository;
using StudentGradebookApi.Repositories.Main;
using StudentGradebookApi.Repositories.StudentsRepository;
using StudentGradebookApi.Repositories.SubjectsRepository;
using StudentGradebookApi.Services.UserServices;

namespace StudentGradebookApi.Services.SubjectClassServices
{
    public class ClassSubjectsService : IClassSubjectsService
    {
        private readonly IClassSubjectsRepository _classSubjectsRepository;
        private readonly ISubjectsRepository _subjectsRepository;
        public ClassSubjectsService(IClassSubjectsRepository classSubjectsRepository, ISubjectsRepository subjectsRepository)
        {
            _classSubjectsRepository = classSubjectsRepository;
            _subjectsRepository = subjectsRepository;
        }

        public async Task<NewClassSubject> AddClassesAsync(NewClassSubject classSubjects)
        {
            Subjects newClass = new Subjects();
            newClass.Description = classSubjects.Description;
            newClass.SubjectName = classSubjects.SubjectName;
            newClass.SubjectCode = classSubjects.SubjectCode;
            await _subjectsRepository.AddAsync(newClass);
            await _classSubjectsRepository.SaveChangesAsync();


            return classSubjects;
        }
    }
}
