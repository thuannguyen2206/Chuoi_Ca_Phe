using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Auths
{
    public class ResetPasswordDto
    {
        public string Email { get; set; }

        public int Code { get; set; }

        public string Password { get; set; }
    }
}
