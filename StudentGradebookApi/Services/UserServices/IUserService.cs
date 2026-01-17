using StudentGradebookApi.DTOs.Users;
using StudentGradebookApi.Models;

namespace StudentGradebookApi.Services.UserServices
{
    public interface IUserService
    {
        Task<WebUsers?> RegisterAsync(LoginDTO request);
        Task<TokenResponse?> LoginAsync(LoginDTO request);
        Task<TokenResponse?> RefreshTokensAsync(RefreshTokenRequest request);
        Task<WebUsers?> GetUserByIdAsync(int id);
        Task DeleteUserAsync(int id);
    }
}
