using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Models.Promotion
{
    public class PromotionViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Discount percent is required")]
        public int DiscountPercent { get; set; }

        [Required(ErrorMessage = "Discount code is required")]
        public string DiscountCode { get; set; }

        public string Description { get; set; }

        public DateTime ExpireTime { get; set; }

        public DateTime StartTime { get; set; }

        public bool IsValid { get; set; }

        public decimal? MaxValueDiscount { get; set; } // Currency

        public bool IsShow { get; set; }
    }
}
