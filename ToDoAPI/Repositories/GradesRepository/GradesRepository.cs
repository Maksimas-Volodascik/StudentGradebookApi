using ToDoAPI.Data;
using ToDoAPI.Models;
using ToDoAPI.Repositories.Main;

namespace ToDoAPI.Repositories.GradesRepository
{
    public class GradesRepository : RepositoryBase<Grades>, IGradesRepository
    {
        public GradesRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
