using StudentGradebookApi.DTOs.Grades;

namespace StudentGradebookApi.Services.GradesServices
{
    public interface IGradesServices
    {
        Task<IEnumerable<StudentGradesBySubjectDTO>> GetStudentGradesBySubjectId();
        Task<IEnumerable<StudentGradesBySubjectDTO>> GetStudentGradesByStudentId();
    }
}
