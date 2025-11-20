using Microsoft.Extensions.Configuration;
using Todo.Application.Services.Interface;
using Todo.Core.Models.Request;
using Todo.Core.Models.Response;
using Todo.Core.Models.Users;
using Todo.Infrastructure.Repository;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Todo.Application.Services
{
    public class UserService(AppDbContext context, IConfiguration configuration) : IUserService
    {
        public async Task<UserLoginResponse> LoginAsync(UserLoginRequest request)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Username == request.Username);

            var token = GenerateJwtToken(user!); 

            var response = new UserLoginResponse
            {
                Token = token,
                User = user
            };
            

            return response;
        }

        public async Task<UserRegisterResponse> RegisterAsync(UserRegisterRequest request)
        {
            var user = new User
            {
                Name = request.Name!,
                Surname = request.Surname!,
                Email = request.Email!,
                Username = request.Username!,
                PhoneNumber = request.PhoneNumber!

            };
            var hash = new PasswordHasher<User>().HashPassword(user, request.Password!);
            user.Password = hash;

            context.Users.Add(user);
            await context.SaveChangesAsync();

            var response = new UserRegisterResponse
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email
            };

            return response;
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
