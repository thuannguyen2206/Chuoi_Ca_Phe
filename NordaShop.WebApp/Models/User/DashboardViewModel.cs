using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.User
{
    public class DashboardViewModel
    {
        public decimal TotalPurchaseCost { get; set; }

        public decimal MonthlyPurchaseCost { get; set; }

        public int UserTotalOrders { get; set; }

        public int AccumulatedPoint { get; set; } // điểm thưởng

    }
}
