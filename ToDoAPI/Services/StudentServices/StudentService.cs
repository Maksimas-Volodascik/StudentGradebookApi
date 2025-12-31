using ToDoAPI.DTOs.Students;
using ToDoAPI.DTOs.Users;
using ToDoAPI.Models;
using ToDoAPI.Repositories;
using ToDoAPI.Services.UserServices;

namespace ToDoAPI.Services.StudentServices
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Students> _studentsRepository;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        public StudentService(IConfiguration configuration, IRepository<Students> studentsRepository, IUserService userService)
        {
            _configuration = configuration;
            _studentsRepository = studentsRepository;
            _userService = userService;
        }

        public async Task<Students?> AddStudentAsync(NewStudent studentData)
        {
            if (studentData == null || studentData.Email.Length <= 5 || studentData.Password.Length <= 5) { 
                return null;
            }
            var newLogin = new LoginDTO();
            newLogin.Email = studentData.Email;
            newLogin.Password = studentData.Password;
            var newUser = await _userService.RegisterAsync(newLogin);
            if(newUser == null)
            {
                return null;
            }
            var student = new Students();
            student.First_name = studentData.First_name;
            student.Last_name = studentData.Last_name;
            student.Date_of_birth = studentData.Date_of_birth;
            student.User = newUser;
            await _studentsRepository.AddAsync(student);
            await _studentsRepository.SaveChangesAsync();

            return student;
        }

        public async Task DeleteStudentAsync(Students student)
        {
            WebUsers userToDelete = await _userService.GetUserByIdAsync(student.UserID);

            _studentsRepository.Delete(student);
            _userService.DeleteUserAsync(userToDelete);
        }

        public async Task<Students?> EditStudentAsync(EditStudent studentData, int id)
        {
            if (studentData == null || studentData.First_name == "" || studentData.Last_name =="")
            {
                return null;
            }

            Students student = await _studentsRepository.GetByIdAsync(id);
            if (student == null)
            {
                return null;
            }
            student.First_name=studentData.First_name;
            student.Last_name=studentData.Last_name;
            student.Date_of_birth=studentData.Date_of_birth;
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
