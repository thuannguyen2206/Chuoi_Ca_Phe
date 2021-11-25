using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Contact : BaseModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public bool IsRead { get; set; }

        public bool IsDelete { get; set; }
    }
}
