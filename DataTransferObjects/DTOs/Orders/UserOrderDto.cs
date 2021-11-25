using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Orders
{
    public class UserOrderDto
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
