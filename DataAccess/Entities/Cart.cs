using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Cart : BaseModel
    {

        public Guid UserId { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}
