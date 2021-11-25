using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Users
{
    public class UserDashboardDto
    {
        public decimal TotalPurchaseCost { get; set; }

        public decimal MonthlyPurchaseCost { get; set; }

        public int UserTotalOrders { get; set; }

        public int AccumulatedPoint { get; set; }
    }
}
