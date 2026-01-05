using ToDoAPI.Data;
using ToDoAPI.Models;
using ToDoAPI.Repositories.Main;

namespace ToDoAPI.Repositories.AttendancesRepository
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
