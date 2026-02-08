
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

        public async Task<Grades> EditGrade(NewGradeDTO newGrade)
        {
            Grades updateGrade = await _gradesRepository.GetGradeByDateAndEnrollmentId(newGrade.gradingDate.Date, newGrade.enrollmentId);

            updateGrade.Grade_Type = newGrade.gradeType;
            updateGrade.Score = newGrade.score;

            _gradesRepository.Update(updateGrade);
            await _gradesRepository.SaveChangesAsync();
            return updateGrade;
        }

        public async Task AddGrade(NewGradeDTO newGrade)
        {
            Grades createGrade = new Grades();
            createGrade.GradingDate = newGrade.gradingDate;
            createGrade.Grade_Type = newGrade.gradeType;
            createGrade.Score = newGrade.score;
            createGrade.EnrollmentId = newGrade.enrollmentId;

            await _gradesRepository.AddAsync(createGrade);
            await _gradesRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<StudentGradesBySubjectDTO>> GetStudentGradesByStudentId(int year, int month)
        {
            return null;
        }

        public async Task<IEnumerable<StudentGradesBySubjectDTO>> GetStudentGradesBySubjectId(int year, int month, int classSubjectId)
        {
            var studentGradeList = await _gradesRepository.GetStudentGradesBySubjectId(year, month, classSubjectId);
            return studentGradeList;
        }
    }
}
