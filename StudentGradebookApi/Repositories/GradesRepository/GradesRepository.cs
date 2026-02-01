using Humanizer;
using Microsoft.EntityFrameworkCore;
using StudentGradebookApi.Data;
using StudentGradebookApi.DTOs.Enrollments;
using StudentGradebookApi.DTOs.Grades;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.Main;

namespace StudentGradebookApi.Repositories.GradesRepository
{
    public class GradesRepository : RepositoryBase<Grades>, IGradesRepository
    {
        private readonly SchoolDbContext _context;
        public GradesRepository(SchoolDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<IEnumerable<StudentGradesBySubjectDTO>> GetStudentGradesByStudentId()
        {
            return null;
        }

        public async Task<IEnumerable<StudentGradesBySubjectDTO>> GetStudentGradesBySubjectId()
        {
            var query = from E in _context.Enrollments
                        join G in _context.Grades
                            on E.Id equals G.EnrollmentId
                        join S in _context.Students
                            on E.StudentID equals S.Id
                        where G.GradingDate.Year == 2026 && G.GradingDate.Month == 1 && E.ClassSubjectId == 3
                        group G by new
                        {
                            S.FirstName,
                            S.LastName,
                            E.ClassSubjectId,
                        }into stud
                        select new StudentGradesBySubjectDTO
                        {
                            FirstName = stud.Key.FirstName,
                            LastName = stud.Key.LastName,
                            ClassSubjectId = stud.Key.ClassSubjectId,
                            Grades = stud.Select(x => new GradesListDTO
                            {
                                Score = x.Score,
                                Grade_Type = x.Grade_Type,
                                GradingDate = x.GradingDate
                            }).ToList()
                        };

            return await query.ToListAsync(); 
        }
    }
}
