using Microsoft.EntityFrameworkCore;
using StudentGradebookApi.Data;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.Main;

namespace StudentGradebookApi.Repositories.ClassesRepository
{
    public class ClassesRepository : RepositoryBase<Classes>, IClassesRepository
    {
        private readonly SchoolDbContext _context;
        public ClassesRepository(SchoolDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Classes>> GetClassesByYearAsync(string academicYear)
        {
            var query = from c in _context.Classes
                        where c.AcademicYear == academicYear
                        select c;

            return await query.ToListAsync();
        }
    }
}
