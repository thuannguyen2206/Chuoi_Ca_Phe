using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Role : BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
