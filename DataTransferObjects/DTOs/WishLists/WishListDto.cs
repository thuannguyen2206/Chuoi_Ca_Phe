using DataTransferObjects.DTOs.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.WishLists
{
    public class WishListDto
    {
        public int ProductId { get; set; }

        public DateTime DateCreated { get; set; } // time add product to wishlist

        public string NameProduct { get; set; }

        public string ImageLink { get; set; }

        public int Quantity { get; set; } // quantity of a product

        public decimal Price { get; set; } // price for an item

        public string SeoAlias { get; set; }

        public List<OptionDto> Options { get; set; } = new List<OptionDto>();
    }

}
