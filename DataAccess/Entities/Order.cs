using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Order : BaseModel
    {
        public Guid UserId { get; set; }

        public Guid OrderCode { get; set; }

        public decimal TotalPrice { get; set; } 

        public OrderStatus OrderStatus { get; set; }

        public decimal DiscountPrice { get; set; }

        public decimal ShippingFee { get; set; } // phí vận chuyển

        public string CustomerName { get; set; }

        public string CustomerPhoneNumber { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerEmail { get; set; }

        public string CustomerAddressOption { get; set; }

        public string OrderNote { get; set; }

        public bool IsPaid { get; set; } // đã thanh toán chưa

        public PaymentMethod PaymentMethod { get; set; }

        public int DeliveryServiceType { get; set; } // Phương thức giao hàng: 1.Express - 2.Standard

        public int ProvinceId { get; set; }

        public int DistrictId { get; set; }

        public string WardCode { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
