using Microsoft.AspNetCore.Http.HttpResults;
using ToDoAPI.DTOs.Teachers;
using ToDoAPI.DTOs.Users;
using ToDoAPI.Models;
using ToDoAPI.Repositories.Main;
using ToDoAPI.Repositories.TeachersRepository;
using ToDoAPI.Services.UserServices;

namespace ToDoAPI.Services.TeacherServices
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeachersRepository _teachersRepository;
        private readonly IUserService _userService;
        public TeacherService(ITeachersRepository teachersRepository, IUserService userService) { 
            _teachersRepository = teachersRepository;
            _userService = userService;
        }
        public async Task<Teachers?> AddTeacherAsync(NewTeacherDTO teacherData)
        {
            // check if classID is not occupied
            if (teacherData == null) return null;
            
            LoginDTO registrationDto = new LoginDTO();
            registrationDto.Email = teacherData.Email;
            registrationDto.Password = teacherData.Password;
            var registeredUser = await _userService.RegisterAsync(registrationDto);
            if (registeredUser == null) return null;


            Teachers newTeacher = new Teachers();
            newTeacher.FirstName = teacherData.FirstName;
            newTeacher.LastName = teacherData.LastName;
            newTeacher.UserID = registeredUser.Id;
            newTeacher.ClassId = teacherData.ClassId;

            await _teachersRepository.AddAsync(newTeacher);
            await _teachersRepository.SaveChangesAsync();
            return newTeacher;
        }

        public async Task<Teachers?> EditTeacherAsync(TeacherDTO teacher)
        {
            Teachers? updateTeacher = await _teachersRepository.GetByIdAsync(teacher.Id);
            if(updateTeacher == null) return null;

            updateTeacher.FirstName = teacher.FirstName;
            updateTeacher.LastName = teacher.LastName;
            updateTeacher.ClassId = teacher.ClassId;

            _teachersRepository.Update(updateTeacher);
            await _teachersRepository.SaveChangesAsync();

            return updateTeacher;
        }

        public async Task<Teachers?> GetTeacherByIdAsync(int id)
        {
            var teacher = await _teachersRepository.GetByIdAsync(id);
            return teacher;
        }

        public async Task<IEnumerable<Teachers?>> GetAllTeachersAsync()
        {
            var teacherList = await _teachersRepository.GetAllAsync();
            return teacherList;
        }
    }
}
