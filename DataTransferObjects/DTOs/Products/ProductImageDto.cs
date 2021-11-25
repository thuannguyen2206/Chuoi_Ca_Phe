using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Products
{
    public class ProductImageDto
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public int ProductId { get; set; }

        public string ImageLink { get; set; }

        public bool IsDefault { get; set; }

    }
}
