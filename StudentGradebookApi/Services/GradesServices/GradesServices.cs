
using StudentGradebookApi.DTOs.Grades;
using StudentGradebookApi.Models;
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

        public async Task AddGrade(byte score, string gradeType, DateTime gradingDate, int enrollmentId)
        {
            Grades newGrade = new Grades();
            newGrade.GradingDate = gradingDate;
            newGrade.Grade_Type = gradeType;
            newGrade.Score = score;
            newGrade.EnrollmentId = enrollmentId;

            await _gradesRepository.AddAsync(newGrade);
            await _gradesRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<StudentGradesBySubjectDTO>> GetStudentGradesByStudentId(int year, int month)
        {
            return null;
        }
        public async Task<IEnumerable<StudentGradesBySubjectDTO>> GetStudentGradesBySubjectId(int year, int month)
        {
            var studentGradeList = await _gradesRepository.GetStudentGradesBySubjectId(year, month);
            return studentGradeList;
        }
    }
}
