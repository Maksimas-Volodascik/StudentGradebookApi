using ToDoAPI.Data;
using ToDoAPI.Models;
using ToDoAPI.Repositories.Main;

namespace ToDoAPI.Repositories.UsersRepository
{
    public class UsersRepository : RepositoryBase<WebUsers>, IUsersRepository
    {
        private readonly SchoolDbContext _context;
        public UsersRepository(SchoolDbContext context) : base(context) { 
            _context = context;
        }
    }
}
