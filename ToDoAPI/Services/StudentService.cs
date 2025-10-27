using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ToDoAPI.DTOs;
using ToDoAPI.Models;
using ToDoAPI.Repositories;

namespace ToDoAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Students> _studentRepository;
        private readonly IConfiguration _configuration;
        public StudentService(IConfiguration configuration, IRepository<Students> studentRepository)
        {
            _configuration = configuration;
            _studentRepository = studentRepository;
        }
        public async Task<IEnumerable<Students>> GetAllStudentsAsync() =>
            await _studentRepository.GetAllAsync();
        public async Task<Students?> GetStudentByIdAsync(int id) =>
            await _studentRepository.GetByIdAsync(id);
        public async Task DeleteStudentAsync(Students student)
        {
            _studentRepository.Delete(student);
            await _studentRepository.SaveChangesAsync();
        }
        public async Task<Students?> RegisterAsync(StudentData studentData)
        {
            if (await _studentRepository.GetByEmailAsync(studentData.email) != null)
            {
                return null; //User exists
            }
            var student = new Students();
            var passwordHasher = new PasswordHasher<Students>();
            var hashedPassword = passwordHasher.HashPassword(student, studentData.password);
            student.first_name = studentData.first_name;
            student.last_name = studentData.last_name;
            student.email = studentData.email;
            student.passwordHash = hashedPassword;
            student.status = studentData.status;

            await _studentRepository.AddAsync(student);
            await _studentRepository.SaveChangesAsync();

            return student;
        }
        public async Task<TokenResponse?> LoginAsync(StudentData studentData)
        {
            var student = await _studentRepository.GetByEmailAsync(studentData.email);
            if (student is null || new PasswordHasher<Students>().VerifyHashedPassword(student, student.passwordHash, studentData.password) == PasswordVerificationResult.Failed)
            {
                return null;
            }
            var response = new TokenResponse
            {
                AccessToken = CreateToken(student),
                RefreshToken = await GenerateAndSaveRefreshTokenAsyc(student),
            };
            return response;

        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        private async Task<string> GenerateAndSaveRefreshTokenAsyc(Students student)
        {
            var refreshToken = GenerateRefreshToken();
            student.refreshToken = refreshToken;
            student.refreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _studentRepository.SaveChangesAsync();
            return refreshToken;
        }
        private string CreateToken(Students students)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, students.email),
                new Claim(ClaimTypes.NameIdentifier, students.student_id.ToString()),
                new Claim(ClaimTypes.Role, students.role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("AppSettings:Issuer"),
                audience: _configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
