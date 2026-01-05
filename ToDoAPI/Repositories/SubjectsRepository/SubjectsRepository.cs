using ToDoAPI.Data;
using ToDoAPI.Models;
using ToDoAPI.Repositories.Main;

namespace ToDoAPI.Repositories.SubjectsRepository
{
    public class SubjectsRepository : RepositoryBase<Subjects>, ISubjectsRepository
    {
        public SubjectsRepository(SchoolDbContext context) : base(context) { }
    }
}
