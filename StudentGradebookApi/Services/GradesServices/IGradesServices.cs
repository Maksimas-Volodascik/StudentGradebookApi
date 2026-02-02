using StudentGradebookApi.DTOs.Grades;

namespace StudentGradebookApi.Services.GradesServices
{
    public interface IGradesServices
    {
        Task<IEnumerable<StudentGradesBySubjectDTO>> GetStudentGradesBySubjectId(int year, int month);
        Task<IEnumerable<StudentGradesBySubjectDTO>> GetStudentGradesByStudentId(int year, int month);
    }
}
