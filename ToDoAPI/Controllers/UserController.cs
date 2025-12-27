using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ToDoAPI.DTOs.Users;
using ToDoAPI.Models;
using ToDoAPI.Services.UserServices;

namespace ToDoAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        //will need to add more services (teachers, classes etc).

        public UserController(IConfiguration configuration, IUserService userService)
        {
            _userService = userService;
        }    
    
        //Register user
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser (LoginDTO loginDto)
        {
            var user = await _userService.RegisterAsync(loginDto);
            if (user == null)
            {
                return BadRequest("Error.");
            }
            return Ok();
        }
        //Login user
        [HttpPost("login")]
        public async Task<ActionResult<TokenResponse>> LoginUser (LoginDTO loginDto)
        {
            var response = await _userService.LoginAsync(loginDto);
            if (response is null)
            {
                return BadRequest("Invalid email or password");
            }
            return Ok(response);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponse>> RefreshToken(RefreshTokenRequest request)
        {
            var result = await _userService.RefreshTokensAsync(request);
            if (result is null || result.AccessToken is null || result.RefreshToken is null)
                return Unauthorized("Invalid refresh token.");
            return Ok(result);
        }
        /*[Authorize(Roles ="Admin")]
          [HttpGet("admin-only")]
          public IActionResult AdminOnlyOnlyEndpoint()
          {
              return Ok("You are admin!");
          }*/
    }
}
