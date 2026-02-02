using StudentGradebookApi.DTOs.Grades;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.Main;

namespace StudentGradebookApi.Repositories.GradesRepository
{
    public interface IGradesRepository : IRepositoryBase<Grades>
    {
        Task<IEnumerable<StudentGradesBySubjectDTO>> GetStudentGradesBySubjectId(int year, int month);
        Task<IEnumerable<StudentGradesBySubjectDTO>> GetStudentGradesByStudentId();
    }
}
