using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Auths
{
    public class SignUpDto
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string RePassword { get; set; }
    }
}
