using ToDoAPI.DTOs.SubjectClass;
using ToDoAPI.Models;
using ToDoAPI.Repositories.ClassesRepository;
using ToDoAPI.Repositories.ClassSubjectsRepository;
using ToDoAPI.Repositories.Main;
using ToDoAPI.Repositories.StudentsRepository;
using ToDoAPI.Repositories.SubjectsRepository;
using ToDoAPI.Services.UserServices;

namespace ToDoAPI.Services.SubjectClassServices
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
