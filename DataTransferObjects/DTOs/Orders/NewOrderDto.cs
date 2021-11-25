using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Orders
{
    public class NewOrderDto
    {
        public string DiscountCode { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerAddressOption { get; set; }

        public string CustomerEmail { get; set; }

        public string OrderNote { get; set; }

        public int DeliveryServiceType { get; set; }

        public decimal ShippingFee { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public bool IsPaid { get; set; }

        public int ProvinceId { get; set; }

        public int DistrictId { get; set; }

        public string WardCode { get; set; }

        public List<NewOrderItemDto> NewOrderItems { get; set; }
    }

    public class NewOrderItemDto
    {
        public int ItemId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; } // quantity for an item

        public decimal Price { get; set; } // price for a product

        public int SizeOptionId { get; set; }
    }
}
