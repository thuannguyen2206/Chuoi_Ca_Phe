using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Carts
{
    public class CartItemDto
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ImageLink { get; set; }

        public string SeoAlias { get; set; }

        public int CartId { get; set; }

        public int Quantity { get; set; } // quantity of a product

        public decimal Price { get; set; } // price for an item (subject discount price)

        public string ColorName { get; set; }

        public string SizeName { get; set; }
    }
}
