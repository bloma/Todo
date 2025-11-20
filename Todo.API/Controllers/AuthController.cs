using Microsoft.AspNetCore.Mvc;
using Todo.Application.Services.Interface;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserService service) : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login()
        {
            var result = service.LoginAsync(null);
            // Placeholder for login logic
            return Ok("Login successful");
        }

        [HttpPost("register")]
        public IActionResult Register()
        {
            var result = service.RegisterAsync(null);
            // Placeholder for registration logic
            return Ok("Registration successful");
        }
    }
}
