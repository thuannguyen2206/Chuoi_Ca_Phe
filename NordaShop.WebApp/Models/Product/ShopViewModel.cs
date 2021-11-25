using Common.Enums;
using NordaShop.WebApp.Models.Brand;
using NordaShop.WebApp.Models.Category;
using NordaShop.WebApp.Models.Option;
using NordaShop.WebApp.Models.Promotion;
using NordaShop.WebApp.Models.Tag;
using Service.ApiResponse;
using System.Collections.Generic;

namespace NordaShop.WebApp.Models.Product
{
    public class ShopViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }

        public PageResult<List<ProductViewModel>> Products { get; set; }

        public List<OptionViewModel> Options { get; set; }

        public List<BrandViewModel> Brands { get; set; }

        public List<TagViewModel> Tags { get; set; }

        public PromotionViewModel Promotion { get; set; }

        public SortProduct FilterProduct { get; set; }

        public int PageSize { get; set; }

        public decimal MaxPrice { get; set; }

    }
}
