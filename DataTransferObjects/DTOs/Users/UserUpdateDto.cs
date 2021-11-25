using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Users
{
    public class UserUpdateDto
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AvatarLink { get; set; }

        public string Username { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

        public bool IsAdmin { get; set; }

        public IFormFile AvatarFile { get; set; }
    }
}
