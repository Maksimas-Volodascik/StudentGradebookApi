using ToDoAPI.Data;
using ToDoAPI.Models;
using ToDoAPI.Repositories.Main;

namespace ToDoAPI.Repositories.ClassesRepository
{
    public class ClassesRepository : RepositoryBase<Classes>, IClassesRepository
    {
        public ClassesRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
