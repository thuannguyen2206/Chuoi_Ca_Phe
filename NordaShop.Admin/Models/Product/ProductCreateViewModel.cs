using Microsoft.AspNetCore.Http;
using NordaShop.Admin.Models.Option;
using NordaShop.Admin.Models.Tag;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NordaShop.Admin.Models.Product
{
    public class ProductCreateViewModel
    {
        [Required(ErrorMessage = "Product name is required")]
        [MaxLength(200, ErrorMessage = "Product name too long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product code is required")]
        [MaxLength(100, ErrorMessage = "Product code too long")]
        public string CodeProduct { get; set; }

        public decimal Price { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal DiscountPrice { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public int Stock { get; set; }

        public bool IsActive { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        public int ColorId { get; set; }

        public bool OnTopHot { get; set; }

        public bool OnBanner { get; set; }

        public List<IFormFile> Files { get; set; }

        [Required(ErrorMessage = "Seo alias is required")]
        [MaxLength(500, ErrorMessage = "Seo alias too long")]
        public string SeoAlias { get; set; }

        public List<OptionViewModel> Options { get; set; }

        public List<TagViewModel> Tags { get; set; }

    }
}
