using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Models.Order
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDefaultLink { get; set; }

        public int OrderId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string ColorName { get; set; }

        public string SizeName { get; set; }
    }
}
