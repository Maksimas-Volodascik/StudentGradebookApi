using StudentGradebookApi.Data;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.ClassesRepository;
using StudentGradebookApi.Repositories.Main;

namespace StudentGradebookApi.Repositories.ClassSubjectsRepository
{
    public class ClassSubjectsRepository : RepositoryBase<ClassSubjects>, IClassSubjectsRepository
    {
        public ClassSubjectsRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
