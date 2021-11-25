using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Models.Home
{
    public class HomeViewModel
    {
        public int ActiveProduct { get; set; } // Product active quantity

        public int ProductSold { get; set; } // Products sold

        public decimal MonthlyIncome { get; set; } // Monthly income

        public int TotalUsers { get; set; } // Total users

        public int TotalOrders { get; set; } // Total orders

        public decimal TotalIncome { get; set; } // Total income
    }
}
