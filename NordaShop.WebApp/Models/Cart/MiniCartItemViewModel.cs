using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Cart
{
    public class MiniCartItemViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ImageLink { get; set; }

        public int CartId { get; set; }

        public string SeoAlias { get; set; }

        public int Quantity { get; set; } // quantity of a product

        public decimal Price { get; set; } // price for an item
    }
}
