using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Models.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Name { get; set; }

        public string CodeProduct { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountPrice { get; set; }

        public int TotalInStock { get; set; }

        public bool IsActive { get; set; }

        public string BrandName { get; set; }

        public int BrandId { get; set; }

        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string DefaultImage { get; set; }

        public double RatingStar { get; set; }

        public int RatingCount { get; set; }

        public int OrderCount { get; set; }

       // public List<ProductImageDto> ProductImages { get; set; }
    }
}
