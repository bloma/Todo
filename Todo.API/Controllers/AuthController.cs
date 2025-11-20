using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services.Interface;
using Todo.Core.Models.Request;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserService service) : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginRequest request)
        {
            var result = service.LoginAsync(request);
            // Placeholder for login logic
            return Ok(result);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegisterRequest request)
        {
            var result = service.RegisterAsync(request);
            // Placeholder for registration logic
            return Ok(result);
        }
    }
}
