using NordaShop.WebApp.Models.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.User
{
    public class WishListViewModel
    {
        public int ProductId { get; set; }

        public DateTime DateCreated { get; set; } // time add product to wishlist

        public string NameProduct { get; set; }

        public string ImageLink { get; set; }

        public int Quantity { get; set; } // quantity of a product

        public decimal Price { get; set; } // price for an item

        public string SeoAlias { get; set; }

        public List<OptionViewModel> Options { get; set; } = new List<OptionViewModel>();
    }
}
