using StudentGradebookApi.DTOs.Grades;
using StudentGradebookApi.Models;

namespace StudentGradebookApi.Services.GradesServices
{
    public interface IGradesServices
    {
        Task<IEnumerable<StudentGradesBySubjectDTO>> GetStudentGradesBySubjectId(int year, int month, int classSubjectId);
        Task<IEnumerable<StudentGradesBySubjectDTO>> GetStudentGradesByStudentId(int year, int month);
        Task AddGrade(NewGradeDTO newGrade);
        Task<Grades> EditGrade(NewGradeDTO newGrade);
    }
}
