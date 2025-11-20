using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Core.Models.Response
{
    public class UserRegisterResponse
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        string? Username { get; set; }
        public string? Email { get; set; }
    }
}
