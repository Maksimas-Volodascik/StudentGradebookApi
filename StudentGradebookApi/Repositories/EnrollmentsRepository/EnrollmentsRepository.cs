using Microsoft.EntityFrameworkCore;
using StudentGradebookApi.Data;
using StudentGradebookApi.DTOs.Enrollments;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.Main;

namespace StudentGradebookApi.Repositories.EnrollmentsRepository
{
    public class EnrollmentsRepository : RepositoryBase<Enrollments>, IEnrollmentsRepository
    {
        private readonly SchoolDbContext _context;
        public EnrollmentsRepository(SchoolDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentEnrollments>> GetStudentEnrollmentsAsync(int id)
        {
            var query = from E in _context.Enrollments
                        join S in _context.Students
                            on E.StudentID equals S.Id
                        join CS in _context.ClassSubjects
                            on E.ClassSubjectId equals CS.Id
                        where S.UserID == id
                        select new StudentEnrollments
                        {
                            FirstName = S.FirstName,
                            LastName = S.LastName,
                            ClassId = CS.Id,
                            Status = E.Status,
                        };
            return await query.ToListAsync();
        }
    }
}
