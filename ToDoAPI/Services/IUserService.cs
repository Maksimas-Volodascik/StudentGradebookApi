using ToDoAPI.DTOs;
using ToDoAPI.Models;

namespace ToDoAPI.Services
{
    public interface IUserService
    {
        Task<WebUsers?> RegisterAsync(LoginDTO request);
        Task<TokenResponse?> LoginAsync(LoginDTO request);
        Task<TokenResponse?> RefreshTokensAsync(RefreshTokenRequest request);
    }
}
