using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using ToDoAPI.DTOs.Users;
using ToDoAPI.Models;
using ToDoAPI.Repositories;

namespace ToDoAPI.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IRepository<WebUsers> _userRepository;
        private readonly IConfiguration _configuration;
        public UserService(IConfiguration configuration, IRepository<WebUsers> userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }
        public async Task<WebUsers?> RegisterAsync(LoginDTO loginDto)
        {
            if (await _userRepository.GetByEmailAsync(loginDto.Email) != null || loginDto.Password.Length <= 5 || loginDto.Email.Length <= 5)
            {
                return null; //User exists
            }
            var user = new WebUsers();
            var passwordHasher = new PasswordHasher<WebUsers>();
            var hashedPassword = passwordHasher.HashPassword(user, loginDto.Password);
            user.Email = loginDto.Email;
            user.PasswordHash = hashedPassword;

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return user;
        }
        public async Task<TokenResponse?> LoginAsync(LoginDTO loginDto)
        {
            var user = await _userRepository.GetByEmailAsync(loginDto.Email);
            if (user is null || new PasswordHasher<WebUsers>().VerifyHashedPassword(user, user.PasswordHash, loginDto.Password) == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return await CreateTokenResponse(user); 
        }
        private async Task<TokenResponse> CreateTokenResponse(WebUsers user)
        {
            return new TokenResponse
            {
                AccessToken = CreateToken(user),
                RefreshToken = await GenerateAndSaveRefreshTokenAsyc(user)
            };
        }
        private async Task<WebUsers?> ValidateRefreshTokenAsync(int userId, string refreshToken)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.UtcNow)
            {
                return null;
            }
            return user;
        }
        public async Task<TokenResponse?> RefreshTokensAsync(RefreshTokenRequest request)
        {
            var user = await ValidateRefreshTokenAsync(request.UserID, request.RefreshToken);
            if (user is null)
                return null;
            return await CreateTokenResponse(user);
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        private async Task<string> GenerateAndSaveRefreshTokenAsyc(WebUsers user)
        {
            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(14);
            await _userRepository.SaveChangesAsync();
            return refreshToken;
        }
        private string CreateToken(WebUsers user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("AppSettings:Issuer"),
                audience: _configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
