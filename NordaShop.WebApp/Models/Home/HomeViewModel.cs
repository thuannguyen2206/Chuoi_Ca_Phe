using NordaShop.WebApp.Enums;
using NordaShop.WebApp.Models.Brand;
using NordaShop.WebApp.Models.Product;
using NordaShop.WebApp.Models.Slide;
using System.Collections.Generic;

namespace NordaShop.WebApp.Models.Home
{
    public class HomeViewModel
    {
        public List<SlideViewModel> Sliders { get; set; }

        public List<ProductViewModel> BannerProducts { get; set; }

        public List<BrandViewModel> Brands { get; set; }

        public Tab ActiveTab { get; set; }
    }
}
