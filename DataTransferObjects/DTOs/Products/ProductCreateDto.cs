using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace DataTransferObjects.DTOs.Products
{
    public class ProductCreateDto
    {
        public string Name { get; set; }

        public string CodeProduct { get; set; }

        public decimal Price { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal DiscountPrice { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public string SeoAlias { get; set; }

        public int Stock { get; set; }

        public bool IsActive { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        public int ColorId { get; set; }

        public bool OnTopHot { get; set; }

        public bool OnBanner { get; set; }

        public List<IFormFile> Files { get; set; }

        public int[] Options { get; set; }

        public int[] Tags { get; set; }
    }
}
