using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Core.Models.Request
{
    public class UserLoginRequest
    {
        public string? Username { get; set; }
        public string?  Password{ get; set; }
    }
}
