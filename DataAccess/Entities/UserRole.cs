using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class UserRole
    {
        public int RoleId { get; set; }

        public Guid UserId { get; set; }

        public Role Role { get; set; }

        public User User { get; set; }
    }
}
