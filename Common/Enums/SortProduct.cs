using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Enums
{
    public enum SortProduct
    {
        [Display(Name = "Mặc định")]
        Default,

        [Display(Name = "Tên sản phẩm")]
        Name,

        [Display(Name = "Đang giảm giá")]
        OnSale,

        [Display(Name = "Mới nhất")]
        NewArrivals,

        [Display(Name = "Giá thấp nhất")]
        IncrementPrice,
        
        [Display(Name = "Giá cao nhất")]
        DecrementPrice
    }
}
