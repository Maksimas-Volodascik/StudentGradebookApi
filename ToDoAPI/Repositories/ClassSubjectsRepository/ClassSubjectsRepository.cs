using ToDoAPI.Data;
using ToDoAPI.Models;
using ToDoAPI.Repositories.ClassesRepository;
using ToDoAPI.Repositories.Main;

namespace ToDoAPI.Repositories.ClassSubjectsRepository
{
    public class ClassSubjectsRepository : RepositoryBase<ClassSubjects>, IClassSubjectsRepository
    {
        public ClassSubjectsRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
