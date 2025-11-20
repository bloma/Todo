using Microsoft.Extensions.Configuration;
using Todo.Application.Services.Interface;
using Todo.Core.Models.Request;
using Todo.Core.Models.Response;
using Todo.Infrastructure.Repository;

namespace Todo.Application.Services
{
    public class UserService(AppDbContext context, IConfiguration configuration) : IUserService
    {
        public Task<UserLoginResponse> LoginAsync(UserLoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<UserRegisterResponse> RegisterAsync(UserRegisterRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
