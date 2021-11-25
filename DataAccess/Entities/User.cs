using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public bool IsAdmin { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool EmailConfirmed { get; set; }

        public string AvatarLink { get; set; }

        public int AccumulatedPoint { get; set; } // điểm thưởng

        public string ExternalProvider { get; set; }

        public List<UserRole> UserRoles { get; set; }

    }
}
