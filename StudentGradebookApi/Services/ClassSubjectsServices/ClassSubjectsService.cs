using StudentGradebookApi.DTOs.SubjectClass;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.ClassesRepository;
using StudentGradebookApi.Repositories.ClassSubjectsRepository;
using StudentGradebookApi.Repositories.Main;
using StudentGradebookApi.Repositories.StudentsRepository;
using StudentGradebookApi.Repositories.SubjectsRepository;
using StudentGradebookApi.Repositories.TeachersRepository;
using StudentGradebookApi.Services.UserServices;

namespace StudentGradebookApi.Services.SubjectClassServices
{
    public class ClassSubjectsService : IClassSubjectsService
    {
        private readonly IClassSubjectsRepository _classSubjectsRepository;
        private readonly ISubjectsRepository _subjectsRepository;
        private readonly IClassesRepository _classesRepository;
        private readonly ITeachersRepository _teachersRepository;
        public ClassSubjectsService(IClassSubjectsRepository classSubjectsRepository, ISubjectsRepository subjectsRepository, IClassesRepository classesRepository, ITeachersRepository teachersRepository)
        {
            _classSubjectsRepository = classSubjectsRepository;
            _subjectsRepository = subjectsRepository;
            _classesRepository = classesRepository;
            _teachersRepository = teachersRepository;
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

        public async Task<ClassSubjects> AssignSubjectToClassAsync(int classId, int subjectId)
        {
            ClassSubjects classSubjects = new ClassSubjects();
            classSubjects.SubjectId = subjectId;
            classSubjects.ClassId = classId;
            await _classSubjectsRepository.AddAsync(classSubjects);
            await _classSubjectsRepository.SaveChangesAsync();
            return classSubjects;
        }

        public async Task<ClassSubjects> EditSubjectClassTeacher(int classSubjectsId, int teacherId)
        {
            Teachers? newTeacher = await _teachersRepository.GetByIdAsync(teacherId);

            ClassSubjects? newClassSubject = await _classSubjectsRepository.GetByIdAsync(classSubjectsId);

            if (newClassSubject == null || newTeacher == null){
                return null; 
            }else
            {
                newClassSubject.Teachers = newTeacher;
                newClassSubject.TeacherId = teacherId;
                _classSubjectsRepository.Update(newClassSubject);
                await _classSubjectsRepository.SaveChangesAsync();
                return newClassSubject;
            }

        }

        public async Task<IEnumerable<Classes>> GetAllClassesByYear(string year)
        {
            var newClassList = await _classesRepository.GetClassesByYear(year);
            return newClassList;
        }

        public async Task<IEnumerable<ClassSubjects?>> GetAllClassSubjectsAsync()
        {
            var classSubjectsList = await _classSubjectsRepository.GetAllAsync();
            return classSubjectsList;
        }

        public async Task<ClassSubjects?> RemoveSubjectClass(int classSubjectsId)
        {
            ClassSubjects? classSubjects = await _classSubjectsRepository.GetByIdAsync(classSubjectsId);
            if (classSubjects == null)
            {
                return null;
            }
            else
            {
                _classSubjectsRepository.Delete(classSubjects);
                await _classSubjectsRepository.SaveChangesAsync();
            }

                throw new NotImplementedException();
        }
    }
}
