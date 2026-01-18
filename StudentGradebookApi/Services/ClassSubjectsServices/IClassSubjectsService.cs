using StudentGradebookApi.DTOs.SubjectClass;
using StudentGradebookApi.Models;

namespace StudentGradebookApi.Services.SubjectClassServices
{
    public interface IClassSubjectsService
    {
        Task<NewClassSubject> AddClassesAsync(NewClassSubject classSubjects);
        Task<IEnumerable<Classes>> GetAllClassesByYear (string year);
        Task<ClassSubjects> AssignSubjectToClassAsync (int classId, int subjectId);
        Task<ClassSubjects?> RemoveSubjectClass(int classSubjectsId);
        Task<ClassSubjects> EditSubjectClassTeacher(int classSubjectsId, int teacherId);  //Function to change class teacher
        Task<IEnumerable<ClassSubjects?>> GetAllClassSubjectsAsync();

//GetSubjectsByClass
//GetClassesBySubject
//GetAllClassSubjects

    }
}
