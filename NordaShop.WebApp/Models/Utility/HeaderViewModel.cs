using NordaShop.WebApp.Models.Category;
using NordaShop.WebApp.Models.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Utility
{
    public class HeaderViewModel
    {
        public int WishListCount { get; set; }

        public int CartItemCount { get; set; }

        public List<MenuViewModel> Menus { get; set; }

        public List<CategoryViewModel> Categories { get; set; }

    }
}
