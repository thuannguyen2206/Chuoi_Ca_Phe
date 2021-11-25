using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Product
{
    public class ProductImageViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ImageLink { get; set; }

        public bool IsDefault { get; set; }

        public string Caption { get; set; }
    }
}
