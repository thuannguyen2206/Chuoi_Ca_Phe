using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Orders
{
    public class OrderDto
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
