using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Order
{
    public class OrderTrackingViewModel
    {
        [Required(ErrorMessage = "Bạn chưa nhập mã đơn hàng")]
        public string OrderCode { get; set; }

        public DetailViewModel Detail { get; set; }
    }
}
