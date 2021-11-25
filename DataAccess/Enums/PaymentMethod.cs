using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Enums
{
    public enum PaymentMethod
    {
        [Display(Name = "Thanh toán khi nhận hàng")]
        CashOnDelivery,

        [Display(Name = "Ví momo")]
        Momo,

        [Display(Name = "Ngân Lượng")]
        NganLuong,

        [Display(Name = "Paypal")]
        Paypal
    }
}
