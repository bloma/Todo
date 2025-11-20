using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Todo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController() : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login()
        {
            // Placeholder for login logic
            return Ok("Login successful");
        }

        [HttpPost("register")]
        public IActionResult Register()
        {
            // Placeholder for registration logic
            return Ok("Registration successful");
        }
    }
}
