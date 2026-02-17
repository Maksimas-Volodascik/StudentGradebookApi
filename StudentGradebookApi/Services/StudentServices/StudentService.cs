using StudentGradebookApi.DTOs.Students;
using StudentGradebookApi.DTOs.Users;
using StudentGradebookApi.Models;
using StudentGradebookApi.Repositories.Main;
using StudentGradebookApi.Repositories.StudentsRepository;
using StudentGradebookApi.Services.UserServices;

namespace StudentGradebookApi.Services.StudentServices
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

            NewUserDTO newUser = new NewUserDTO();
            newUser.Email = studentData.Email;
            newUser.Password = studentData.Password;
            newUser.Role = "student";
            var registeredUser = await _userService.RegisterAsync(newUser);
            if(registeredUser == null)
            {
                return null;
            }

            Students student = new Students();
            student.FirstName = studentData.FirstName;
            student.LastName = studentData.LastName;
            student.DateOfBirth = studentData.DateOfBirth;
            student.User = registeredUser.Data;

            await _studentsRepository.AddAsync(student);
            await _studentsRepository.SaveChangesAsync();

            return student;
        }

        public async Task<Students?> DeleteStudentAsync(int id)
        {
            Students? studentToDelete = await _studentsRepository.GetByIdAsync(id);
            if(studentToDelete == null)
            {
                return null;
            }
            await _userService.DeleteUserAsync(studentToDelete.UserID);
            return studentToDelete;
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
