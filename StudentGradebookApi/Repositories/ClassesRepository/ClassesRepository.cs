using StudentGradebookApi.Data;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.Main;

namespace StudentGradebookApi.Repositories.ClassesRepository
{
    public class ClassesRepository : RepositoryBase<Classes>, IClassesRepository
    {
        public ClassesRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
