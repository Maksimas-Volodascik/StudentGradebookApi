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

namespace StudentGradebookApi.Services.SubjectClassServices
{
    public class ClassSubjectsService : IClassSubjectsService
    {
        private readonly IClassSubjectsRepository _classSubjectsRepository;
        private readonly ITeachersRepository _teachersRepository;
        public ClassSubjectsService(IClassSubjectsRepository classSubjectsRepository, ITeachersRepository teachersRepository)
        {
            _classSubjectsRepository = classSubjectsRepository;
            _teachersRepository = teachersRepository;
        }

        public async Task<ClassSubjects> AssignSubjectToClassAsync(CombineClassSubjectDTO combineClassSubjectDTO)
        {
            ClassSubjects classSubjects = new ClassSubjects();
            classSubjects.SubjectId = combineClassSubjectDTO.SubjectId;
            classSubjects.ClassId = combineClassSubjectDTO.ClassId;
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
        public async Task<ClassSubjects?> GetClassSubjectsByIdAsync(int classSubjectsId)
        {
            ClassSubjects? classSubject = await _classSubjectsRepository.GetByIdAsync(classSubjectsId);

            return classSubject;
        }
        public async Task<IEnumerable<ClassSubjectDTO?>> GetAllClassSubjectsAsync()
        {
            var classSubjectsList = await _classSubjectsRepository.GetAllClassSubjectsAsync();
            return classSubjectsList;
        }

        public async Task<ClassSubjects?> RemoveSubjectClassAsync(int classSubjectsId)
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

        public Task<ClassSubjectDTO> CreateNewClassSubjectAsync(ClassSubjectDTO newClassSubject)
        {
            throw new NotImplementedException();
        }
    }
}
