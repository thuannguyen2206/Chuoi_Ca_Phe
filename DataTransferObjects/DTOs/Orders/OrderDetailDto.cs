using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Orders
{
    public class OrderDetailDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDefaultLink { get; set; }

        public int OrderId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string SizeName { get; set; }

    }
}
