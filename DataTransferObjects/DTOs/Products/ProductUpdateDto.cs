using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Products
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CodeProduct { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public string SeoAlias { get; set; }

        public decimal Price { get; set; }

        public decimal OriginalPrice { get; set; }

        public decimal DiscountPrice { get; set; }

        public bool IsActive { get; set; }

        public int BrandId { get; set; }

        public int CategoryId { get; set; }

        public int ColorId { get; set; }

        public bool OnBanner { get; set; }

        public bool OnTopHot { get; set; }

        public int[] Options { get; set; }

        public int[] Tags { get; set; }
    }
}
