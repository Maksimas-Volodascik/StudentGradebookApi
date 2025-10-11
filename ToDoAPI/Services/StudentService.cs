using ToDoAPI.Models;
using ToDoAPI.Repositories;

namespace ToDoAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Students> _studentRepository;
        public StudentService(IRepository<Students> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Students>> GetAllStudentsAsync() =>
            await _studentRepository.GetAllAsync();
        public async Task<Students?> GetStudentByIdAsync(int id) =>
            await _studentRepository.GetByIdAsync(id);
        public async Task AddStudentAsync(Students student){
            await _studentRepository.AddAsync(student);
            await _studentRepository.SaveChangesAsync();
        }
        public async Task DeleteStudentAsync(Students student)
        {
            _studentRepository.Delete(student);
            await _studentRepository.SaveChangesAsync();
        }
    }
}
