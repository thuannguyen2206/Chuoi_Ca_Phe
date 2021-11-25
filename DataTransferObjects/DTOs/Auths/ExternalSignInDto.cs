using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Auths
{
    public class ExternalSignInDto
    {
        public string ExternalProvider { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
