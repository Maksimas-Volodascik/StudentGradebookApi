using StudentGradebookApi.Data;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.Main;

namespace StudentGradebookApi.Repositories.UsersRepository
{
    public class UsersRepository : RepositoryBase<WebUsers>, IUsersRepository
    {
        private readonly SchoolDbContext _context;
        public UsersRepository(SchoolDbContext context) : base(context) { 
            _context = context;
        }
    }
}
