
using StudentGradebookApi.DTOs.Grades;
using StudentGradebookApi.Repositories.GradesRepository;

namespace StudentGradebookApi.Services.GradesServices
{
    public class GradesServices : IGradesServices
    {
        private readonly IGradesRepository _gradesRepository;
        public GradesServices(IGradesRepository gradesRepository)
        {
            _gradesRepository = gradesRepository;
        }
        public async Task<IEnumerable<StudentGradesBySubjectDTO>> GetStudentGradesByStudentId()
        {
            var studentGradeList = await _gradesRepository.GetStudentGradesBySubjectId();
            return studentGradeList;
        }

        public async Task<IEnumerable<StudentGradesBySubjectDTO>> GetStudentGradesBySubjectId()
        {
            var studentGradeList = await _gradesRepository.GetStudentGradesBySubjectId();
            return studentGradeList;
        }
    }
}
