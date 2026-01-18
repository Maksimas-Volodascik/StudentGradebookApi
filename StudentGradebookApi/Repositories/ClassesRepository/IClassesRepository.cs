using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.Main;

namespace StudentGradebookApi.Repositories.ClassesRepository
{
    public interface IClassesRepository : IRepositoryBase<Classes>
    {
        //GetClassesByYear
        Task<IEnumerable<Classes>> GetClassesByYear(string academicYear);
    }
}
