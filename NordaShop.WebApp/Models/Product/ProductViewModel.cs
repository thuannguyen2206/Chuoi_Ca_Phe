using DataTransferObjects.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Name { get; set; }

        public string CodeProduct { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }

        public string BrandName { get; set; }

        public int CategoryId { get; set; }

        public decimal DiscountPrice { get; set; }

        public string DiscountPercent 
        {
            get
            {
                if (DiscountPrice > 0)
                {
                    int percent = (int)(DiscountPrice / Price * 100);
                    return string.Format("{0}%", percent);
                }
                return string.Empty;
            }
        }

        public string Title { get; set; }

        public string SeoAlias { get; set; }

        public string Description { get; set; }

        public string DefaultImage { get; set; }

        public double RatingStar { get; set; }

        public int RatingCount { get; set; }

        public int OrderCount { get; set; }

        public int ColorId { get; set; }

        public string ColorName { get; set; }

        public List<ProductImageViewModel> ProductImages { get; set; }
    }
}
