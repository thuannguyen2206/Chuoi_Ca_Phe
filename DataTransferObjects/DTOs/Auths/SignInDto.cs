using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Auths
{
    public class SignInDto
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public bool AdminRole { get; set; }
    }
}
