using Todo.Core.Models.Request;
using Todo.Core.Models.Response;

namespace Todo.Application.Services.Interface
{
    public interface IUserService
    {
        Task<UserRegisterResponse> RegisterAsync(UserRegisterRequest request);
        Task<UserLoginResponse> LoginAsync(UserLoginRequest request);
    }
}
