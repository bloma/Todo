using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Core.Models.Request
{
    public class UserRegisterRequest
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        string? Username { get; set; }
        string? Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
