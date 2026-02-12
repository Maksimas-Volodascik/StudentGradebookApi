using NuGet.DependencyResolver;
using StudentGradebookApi.DTOs.Teachers;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.Main;

namespace StudentGradebookApi.Repositories.TeachersRepository
{
    public interface ITeachersRepository : IRepositoryBase<Teachers>
    {
        Task<List<TeacherDTO>> GetTeachersWithSubjectsAsync();
    }
}
