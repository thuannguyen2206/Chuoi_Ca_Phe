using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Cart
{
    public class CheckoutViewModel
    {
        public List<CheckoutDetailViewModel> CheckoutDetails { get; set; } = new List<CheckoutDetailViewModel>();


        [Required(ErrorMessage = "Name is required")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string CustomerPhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string CustomerAddress { get; set; }

        public string CustomerAddressOption { get; set; }

        public string OrderNote { get; set; }

        public int DiscountPercent { get; set; }

        public string DiscountCode { get; set; }

        [Required(ErrorMessage = "Province is required")]
        public int ProvinceId { get; set; }

        [Required(ErrorMessage = "District is required")]
        public int DistrictId { get; set; }

        [Required(ErrorMessage = "Ward is required")]
        public string WardCode { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public bool IsPaid { get; set; }

        public int DeliveryServiceType { get; set; }

        public decimal ShippingFee { get; set; }
    }

    public class CheckoutDetailViewModel
    {
        public string ProductName { get; set; }

        public string ProductSortName
        {
            get
            {
                if (this.ProductName.Length > 30)
                {
                    return string.Format("{0}...", this.ProductName.Substring(0, 30));
                }
                return this.ProductName;
            }
        }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }

}
