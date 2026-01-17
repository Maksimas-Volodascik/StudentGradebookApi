using StudentGradebookApi.Data;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.Main;

namespace StudentGradebookApi.Repositories.EnrollmentsRepository
{
    public class EnrollmentsRepository : RepositoryBase<Enrollments>, IEnrollmentsRepository
    {
        public EnrollmentsRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
