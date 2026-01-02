using ToDoAPI.DTOs.Users;
using ToDoAPI.Models;

namespace ToDoAPI.Services.UserServices
{
    public interface IUserService
    {
        Task<WebUsers?> RegisterAsync(LoginDTO request);
        Task<TokenResponse?> LoginAsync(LoginDTO request);
        Task<TokenResponse?> RefreshTokensAsync(RefreshTokenRequest request);
        Task<WebUsers?> GetUserByIdAsync(int id);
        Task DeleteUserAsync(WebUsers user);
    }
}
