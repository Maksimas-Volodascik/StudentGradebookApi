using StudentGradebookApi.DTOs.ClassSubjects;
using StudentGradebookApi.DTOs.SubjectClass;
using StudentGradebookApi.Models;

namespace StudentGradebookApi.Services.SubjectClassServices
{
    public interface IClassSubjectsService
    {
        Task<ClassSubjects> AssignSubjectToClassAsync (CombineClassSubjectDTO combineClassSubjectDTO);
        Task<ClassSubjects?> RemoveSubjectClassAsync(int classSubjectsId);
        Task<ClassSubjects> EditSubjectClassTeacher(int? classSubjectsId, int? teacherId);  //Function to change class teacher
        Task<IEnumerable<ClassSubjectDTO?>> GetAllClassSubjectsAsync();
        Task<ClassSubjects?> GetClassSubjectsByIdAsync(int classSubjectsId);
        Task<ClassSubjectDTO> CreateNewClassSubjectAsync(ClassSubjectDTO newClassSubject);
    }
}
