using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class StoreLocation : BaseModel
    {
        public string Name { get; set; } // trụ sở chính

        public string Address { get; set; }

        public string PhoneNumer { get; set; }

        public string PhoneNumerOption { get; set; }

        public string Email { get; set; }

        public bool IsDefault { get; set; }
    }
}
