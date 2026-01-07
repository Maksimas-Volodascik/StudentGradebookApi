using ToDoAPI.DTOs.Students;
using ToDoAPI.DTOs.Users;
using ToDoAPI.Models;
using ToDoAPI.Repositories.Main;
using ToDoAPI.Repositories.StudentsRepository;
using ToDoAPI.Services.UserServices;

namespace ToDoAPI.Services.StudentServices
{
    public class StudentService : IStudentService
    {
        private readonly IStudentsRepository _studentsRepository;
        private readonly IUserService _userService;
        public StudentService(IUserService userService, IStudentsRepository studentsRepository)
        {
            _studentsRepository = studentsRepository;
            _userService = userService;
        }

        public async Task<Students?> AddStudentAsync(NewStudent studentData)
        {
            if (studentData == null || studentData.Email.Length <= 5 || studentData.Password.Length <= 5) { 
                return null;
            }
            LoginDTO registrationDto = new LoginDTO();
            registrationDto.Email = studentData.Email;
            registrationDto.Password = studentData.Password;
            var registeredUser = await _userService.RegisterAsync(registrationDto);
            if(registeredUser == null)
            {
                return null;
            }
            var student = new Students();
            student.FirstName = studentData.FirstName;
            student.LastName = studentData.LastName;
            student.DateOfBirth = studentData.DateOfBirth;
            student.User = registeredUser;
            await _studentsRepository.AddAsync(student);
            await _studentsRepository.SaveChangesAsync();

            return student;
        }
        public async Task<Students?> EditStudentAsync(EditStudent studentData, int id)
        {
            if (studentData == null || studentData.FirstName == "" || studentData.LastName =="")
            {
                return null;
            }

            Students ?student = await _studentsRepository.GetByIdAsync(id);
            if (student == null)
            {
                return null;
            }
            student.FirstName=studentData.FirstName;
            student.LastName=studentData.LastName;
            student.DateOfBirth=studentData.DateOfBirth;
            _studentsRepository.Update(student);
            await _studentsRepository.SaveChangesAsync();

            return student;
        }

        public async Task<IEnumerable<Students>> GetAllStudentsAsync()
        {
            return await _studentsRepository.GetAllAsync();
        }

        public async Task<Students?> GetStudentByIdAsync(int id)
        {
            return await _studentsRepository.GetByIdAsync(id);
        }
    }
}
