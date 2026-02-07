using Humanizer;
using Microsoft.AspNetCore.Identity;
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

        public async Task<Grades> GetGradeByDateAndEnrollmentId(DateTime dateTime, int enrollmentId)
        {
            Grades? query = await _context.Grades.FirstOrDefaultAsync(g => g.GradingDay == dateTime && g.EnrollmentId == enrollmentId);
                        
            return query;
        }

        public async Task<IEnumerable<StudentGradesBySubjectDTO>> GetStudentGradesByStudentId()
        {
            return null;
        }

        public async Task<IEnumerable<StudentGradesBySubjectDTO>> GetStudentGradesBySubjectId(int year, int month)
        {
            var query = from S in _context.Students

                        join E in _context.Enrollments
                            on S.Id equals E.StudentID into enrollments
                        from E in enrollments
                        .Where(e => e.ClassSubjectId == 3)

                        join G in _context.Grades
                             on E.Id equals G.EnrollmentId into grades
                        from G in grades
                        .Where(g => g.GradingDate.Year == year && g.GradingDate.Month == month)
                        .DefaultIfEmpty()

                        group G by new
                        {
                            S.FirstName,
                            S.LastName,
                            E.ClassSubjectId,
                            E.Id
                        } into stud

                        select new StudentGradesBySubjectDTO
                        {
                            FirstName = stud.Key.FirstName,
                            LastName = stud.Key.LastName,
                            ClassSubjectId = stud.Key.ClassSubjectId,
                            EnrollmentId = stud.Key.Id,
                            Grades = stud
                            .Where(x => x != null)
                            .Select(x => new GradesListDTO
                            {
                                Score = x.Score,
                                Grade_Type = x.Grade_Type,
                                GradingDate = x.GradingDate
                            })
                            .ToList()
                        };

            return await query.ToListAsync(); 
        }
    }
}
