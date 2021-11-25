using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Models.Order
{
    public class OrderInfoViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public string CustomerAddress { get; set; }

        public int TotalProducts { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public bool IsPaid { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
