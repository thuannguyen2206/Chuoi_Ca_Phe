using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Product : BaseModel
    {
        public string Name { get; set; }

        public string CodeProduct { get; set; }

        public decimal Price { get; set; } // giá bán

        public decimal OriginalPrice { get; set; } // giá gốc

        public decimal DiscountPrice { get; set; } 

        public int TotalInStock { get; set; } // số lượng còn trong kho

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public bool OnTopHot { get; set; }

        public bool OnBanner { get; set; }

        public int BrandId { get; set; }

        public int ViewCount { get; set; }

        public int OrderCount { get; set; }

        public int CategoryId { get; set; }

        public int ColorId { get; set; }

        public Category Category { get; set; }

        public Brand Brand { get; set; }

        public List<ProductImage> ProductImages { get; set; }

        public List<ProductDetail> ProductDetails { get; set; }

        public List<CartItem> CartItems { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public List<ProductOption> ProductOptions { get; set; }

        public List<TagInProduct> TagInProducts { get; set; }

    }
}
