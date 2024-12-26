using Authentication_System_with_Test_Models.Authentication_Folders.Auth_Models.User_Models;
using Authentication_System_with_Test_Models.Authentication_Folders.Auth_Service_Folder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication_System_with_Test_Models.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }








        // Register endpoint
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            try
            {
                await _authService.Register(model);
                return Ok(new { message = "Registration successful." });
            }
            catch (Exception ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }










        // Login endpoint
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            try
            {
                var token = await _authService.Login(model);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

    }
}
