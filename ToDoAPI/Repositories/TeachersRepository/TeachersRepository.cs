using ToDoAPI.Data;
using ToDoAPI.Models;
using ToDoAPI.Repositories.Main;

namespace ToDoAPI.Repositories.TeachersRepository
{
    public class TeachersRepository : RepositoryBase<Teachers> ,ITeachersRepository
    {
        private readonly SchoolDbContext _context;
        public TeachersRepository(SchoolDbContext context): base(context) { 
            _context = context;
        }

        //Custom calls goes here
    }
}
