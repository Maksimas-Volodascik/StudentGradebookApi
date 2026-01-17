using StudentGradebookApi.Data;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.Main;

namespace StudentGradebookApi.Repositories.SubjectsRepository
{
    public class SubjectsRepository : RepositoryBase<Subjects>, ISubjectsRepository
    {
        public SubjectsRepository(SchoolDbContext context) : base(context) { }
    }
}
