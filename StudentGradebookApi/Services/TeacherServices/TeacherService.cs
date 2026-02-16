using Microsoft.AspNetCore.Http.HttpResults;
using StudentGradebookApi.DTOs.Teachers;
using StudentGradebookApi.DTOs.Users;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.Main;
using StudentGradebookApi.Repositories.TeachersRepository;
using StudentGradebookApi.Services.SubjectClassServices;
using StudentGradebookApi.Services.UserServices;

namespace StudentGradebookApi.Services.TeacherServices
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeachersRepository _teachersRepository;
        private readonly IUserService _userService;
        private readonly IClassSubjectsService _classSubjectsService;
        public TeacherService(ITeachersRepository teachersRepository, IUserService userService, IClassSubjectsService classSubjectsService) { 
            _teachersRepository = teachersRepository;
            _userService = userService;
            _classSubjectsService = classSubjectsService;
        }
        public async Task<Teachers?> AddTeacherAsync(TeacherRequestDTO teacherData)
        {
            //todo: check if classID is not occupied
            if (teacherData == null) return null;
            
            NewUserDTO newUser = new NewUserDTO();
            newUser.Email = teacherData.Email;
            newUser.Password = teacherData.Password;
            newUser.Role = "teacher";
            var registeredUser = await _userService.RegisterAsync(newUser);
            if (registeredUser == null) return null;

            Teachers newTeacher = new Teachers();
            newTeacher.FirstName = teacherData.FirstName;
            newTeacher.LastName = teacherData.LastName;
            newTeacher.UserID = registeredUser.Id;
            await _teachersRepository.AddAsync(newTeacher);
            await _teachersRepository.SaveChangesAsync();

            Teachers? getTeacher = await _teachersRepository.GetTeacherByEmail(teacherData.Email);
            await _classSubjectsService.EditSubjectClassTeacher(teacherData.ClassSubjectId, getTeacher.Id);

            return newTeacher;
        }

        public async Task<Teachers?> EditTeacherAsync(int teacherId, TeacherRequestDTO teacher)
        {
            Teachers? updateTeacher = await _teachersRepository.GetByIdAsync(teacherId);
            if(updateTeacher == null) return null;

            updateTeacher.FirstName = teacher.FirstName;
            updateTeacher.LastName = teacher.LastName;
            
            _teachersRepository.Update(updateTeacher);
            await _teachersRepository.SaveChangesAsync();

            await _classSubjectsService.EditSubjectClassTeacher(teacher.ClassSubjectId, teacherId);

            return updateTeacher;
        }

        public async Task<Teachers?> GetTeacherByIdAsync(int id)
        {
            var teacher = await _teachersRepository.GetByIdAsync(id);
            return teacher;
        }

        public async Task<List<TeacherDTO?>> GetAllTeachersAsync()
        {
            var teacherList = await _teachersRepository.GetTeachersWithSubjectsAsync();
            return teacherList;
        }

        public async Task<Teachers?> DeleteTeacherAsync(int id)
        {
            Teachers? teacherToDelete = await _teachersRepository.GetByIdAsync(id);
            if (teacherToDelete == null)
            {
                return null;
            }
            await _userService.DeleteUserAsync(teacherToDelete.UserID);
            return teacherToDelete;
        }
    }
}
