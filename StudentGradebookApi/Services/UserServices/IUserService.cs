using StudentGradebookApi.DTOs.Users;
using StudentGradebookApi.Models;
using StudentGradebookApi.Shared;

namespace StudentGradebookApi.Services.UserServices
{
    public interface IUserService
    {
        Task<Result<WebUsers>> RegisterAsync(NewUserDTO request);
        Task<Result<TokenResponse>> LoginAsync(LoginDTO request);
        Task<TokenResponse> RefreshTokensAsync(RefreshTokenRequest request);
        Task<Result<WebUsers>> GetUserByIdAsync(int id);
        Task<Result> DeleteUserAsync(int id);
    }
}
