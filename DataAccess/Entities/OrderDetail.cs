using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class OrderDetail : BaseModel
    {
        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public int Quantity { get; set; } // quantity for an item

        public decimal Price { get; set; } // price for a product

        public decimal OriginalPrice { get; set; }

        public int SizeOptionId { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}
