using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Order
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public DateTime Datecreated { get; set; }

        public string CustomerName { get; set; }

        public int TotalProducts { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public bool IsPaid { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
