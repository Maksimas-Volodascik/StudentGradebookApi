using StudentGradebookApi.Data;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.Main;

namespace StudentGradebookApi.Repositories.AttendancesRepository
{
    public class AttendancesRepository : RepositoryBase<Attendance>, IAttendancesRepository
    {
        private readonly SchoolDbContext _context;
        public AttendancesRepository(SchoolDbContext context) : base(context)
        {
            _context = context;
        }
        //GetAttendancesByDate
    }
}
