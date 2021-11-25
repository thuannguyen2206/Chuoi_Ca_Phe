using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }

        public bool IsAdmin { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool EmailConfirmed { get; set; }

        public string AvatarLink { get; set; }

        public int AccumulatedPoint { get; set; }
    }
}
