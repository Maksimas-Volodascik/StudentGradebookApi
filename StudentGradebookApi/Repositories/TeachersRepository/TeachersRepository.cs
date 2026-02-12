using Microsoft.EntityFrameworkCore;
using StudentGradebookApi.Data;
using StudentGradebookApi.DTOs.Teachers;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.Main;

namespace StudentGradebookApi.Repositories.TeachersRepository
{
    public class TeachersRepository : RepositoryBase<Teachers>, ITeachersRepository
    {
        private readonly SchoolDbContext _context;
        public TeachersRepository(SchoolDbContext context): base(context) { 
            _context = context;
        }

        public Task<List<TeacherDTO>> GetTeachersWithSubjectsAsync()
        {
            var query = from T in _context.Teachers

                        join CS in _context.ClassSubjects
                            on T.Id equals CS.TeacherId
                            into teacherClassSubjects
                        from CS in teacherClassSubjects.DefaultIfEmpty()

                        join S in _context.Subjects
                            on CS.SubjectId equals S.Id
                            into teacherSubjects
                        from S in teacherSubjects.DefaultIfEmpty()

                        select new TeacherDTO
                        {
                            Id = T.Id,
                            FirstName = T.FirstName,
                            LastName = T.LastName,
                            SubjectName = S != null ? S.SubjectName : null,
                        };

            return query.ToListAsync();
        }

        //Custom calls goes here
    }
}
