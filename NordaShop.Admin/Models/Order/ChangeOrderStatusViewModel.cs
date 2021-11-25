using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Models.Order
{
    public class ChangeOrderStatusViewModel
    {
        public int OrderId { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}
