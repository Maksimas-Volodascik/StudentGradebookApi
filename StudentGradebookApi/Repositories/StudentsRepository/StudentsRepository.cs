using Microsoft.EntityFrameworkCore;
using StudentGradebookApi.Data;
using StudentGradebookApi.DTOs.Students;
using StudentGradebookApi.DTOs.SubjectClass;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.Main;

namespace StudentGradebookApi.Repositories.StudentsRepository
{
    public class StudentsRepository : RepositoryBase<Students> , IStudentsRepository
    {
        private readonly SchoolDbContext _context;
        public StudentsRepository(SchoolDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StudentEnrolledSubject>> GetStudentEnrolledSubjects()
        {
            var query = from S in _context.Students
                        join E in _context.Enrollments
                            on S.Id equals E.StudentID
                       // join C in _context.Classes
                           // on E.ClassID equals C.Id
                        //join Sub in _context.Subjects
                            //on C.Id equals Sub.ClassId
                        select new StudentEnrolledSubject
                        {
                            FirstName = S.FirstName,
                            //Room = C.Room,
                            //SubjectName = Sub.SubjectName,
                            Status = E.Status,
                        };

            return await query.ToListAsync();
        }
    }
}
