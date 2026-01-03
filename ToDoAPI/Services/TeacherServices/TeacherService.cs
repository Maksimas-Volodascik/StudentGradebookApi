using Microsoft.AspNetCore.Http.HttpResults;
using ToDoAPI.Models;
using ToDoAPI.Repositories.Main;

namespace ToDoAPI.Services.TeacherServices
{
    public class TeacherService : ITeacherService
    {
        private readonly IRepositoryBase<Teachers> _teachersRepository;
        public TeacherService(IRepositoryBase<Teachers> teachersRepository) { 
            _teachersRepository = teachersRepository;
        }
        public async Task<Teachers?> AddNewTeacher(Teachers teacherData)
        {
            if (teacherData == null) return null;
            await _teachersRepository.AddAsync(teacherData);
            await _teachersRepository.SaveChangesAsync();
            return teacherData;
        }

        public async Task DeleteTeacher(int id)
        {
            Teachers? teacherToDelete = await _teachersRepository.GetByIdAsync(id);
            if (teacherToDelete == null) return;
            _teachersRepository.Delete(teacherToDelete!);
            await _teachersRepository.SaveChangesAsync();
        }

        public async Task<Teachers?> EditTeacherById(Teachers teacher, int id)
        {
            Teachers? updatedTeacher = await _teachersRepository.GetByIdAsync(id);
            if(updatedTeacher == null) return null;

            updatedTeacher.FirstName = teacher.FirstName;
            // add remaining data
            _teachersRepository.Update(updatedTeacher);
            await _teachersRepository.SaveChangesAsync();

            return updatedTeacher;
        }

        public async Task<Teachers?> GetTeacherById(int id)
        {
            var teacher = await _teachersRepository.GetByIdAsync(id);
            return teacher;
        }

        public async Task<IEnumerable<Teachers?>> GetTeachersAsync()
        {
            var teacherList = await _teachersRepository.GetAllAsync();
            return teacherList;
        }
    }
}
