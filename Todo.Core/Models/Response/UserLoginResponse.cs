using Todo.Core.Models.Users;

namespace Todo.Core.Models.Response
{
    public class UserLoginResponse
    {
        public string? Token { get; set; }
        public User? User { get; set; }
    }
}
