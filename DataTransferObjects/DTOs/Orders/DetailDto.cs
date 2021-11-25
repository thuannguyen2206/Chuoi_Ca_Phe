using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Orders
{
    public class DetailDto
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerAddressOption { get; set; }

        public string OrderNote { get; set; }

        public string CustomerEmail { get; set; }

        public decimal TotalPrice { get; set; }

        public decimal DiscountPrice { get; set; }

        public decimal ShippingFee { get; set; }

        public Guid OrderCode { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public bool IsPaid { get; set; }

        public string QRCodeContent { get; set; }

        public List<OrderDetailDto> OrderDetails { get; set; }
    }
}
