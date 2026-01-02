using Microsoft.EntityFrameworkCore;
using ToDoAPI.Data;
using ToDoAPI.DTOs.SubjectClass;

namespace ToDoAPI.Repositories.Joined
{
    public class JoinedRepository : IJoinedRepository
    {
        private readonly SchoolDbContext _context;
        
        public JoinedRepository(SchoolDbContext context)
        {
            _context = context;

        }
        public async Task<IEnumerable<ClassSubjects>> GetClassSubjectsAsync()
        {
            var query = from c in _context.Classes
                        join s in _context.Subjects
                            on c.Id equals s.Class_id
                        select new ClassSubjects
                        {
                            Academic_year = c.Academic_year,
                            Room = c.Room,
                            Subject_name = s.Subject_name,
                            Subject_code = s.Subject_code
                        };

            return await query.ToListAsync();
        }
    }
}
