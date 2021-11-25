using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Cart
{
    public class CartViewModel
    {
        public int ItemId { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }

        public string DefaultImage { get; set; }

        public string Name { get; set; }

        public string SeoAlias { get; set; }

        public decimal Price { get; set; } // for unit

        public int Quantity { get; set; }

        public int ColorId { get; set; }

        public string ColorName { get; set; }

        public int SizeId { get; set; }

        public string SizeName { get; set; }
    }
}
