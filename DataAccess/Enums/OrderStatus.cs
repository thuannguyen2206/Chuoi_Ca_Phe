using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "Đang xử lý")]
        InProgress,

        [Display(Name = "Đã xác nhận đơn")]
        Confirmed,

        [Display(Name = "Đang giao hàng")]
        Shipping,

        [Display(Name = "Đã nhận hàng")]
        Successed,

        [Display(Name = "Đã hủy đơn")]
        Canceled
    }
}
