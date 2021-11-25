using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class WishList
    {
        public Guid UserId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; }

    }
}
