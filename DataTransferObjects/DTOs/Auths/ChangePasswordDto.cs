using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Auths
{
    public class ChangePasswordDto
    {
        public string Token { get; set; }

        public string Password { get; set; }
    }
}
