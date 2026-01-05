using ToDoAPI.Data;
using ToDoAPI.Models;
using ToDoAPI.Repositories.Main;

namespace ToDoAPI.Repositories.EnrollmentsRepository
{
    public class EnrollmentsRepository : RepositoryBase<Enrollments>, IEnrollmentsRepository
    {
        public EnrollmentsRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
