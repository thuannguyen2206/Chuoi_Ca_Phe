using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Brand
{
    public class BrandViewModel
    {
        public int Id { get; set; }

        public string BrandLogo { get; set; }

        public string BrandName { get; set; }

        public int TotalProducts { get; set; }

        public bool Checked { get; set; }
    }
}
