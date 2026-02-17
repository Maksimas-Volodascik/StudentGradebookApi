using StudentGradebookApi.DTOs.Users;
using StudentGradebookApi.Models;
using StudentGradebookApi.Shared;

namespace StudentGradebookApi.Services.UserServices
{
    public interface IUserService
    {
        Task<Result<WebUsers>> RegisterAsync(NewUserDTO request);
        Task<TokenResponse?> LoginAsync(LoginDTO request);
        Task<TokenResponse?> RefreshTokensAsync(RefreshTokenRequest request);
        Task<WebUsers?> GetUserByIdAsync(int id);
        Task DeleteUserAsync(int id);
    }
}
