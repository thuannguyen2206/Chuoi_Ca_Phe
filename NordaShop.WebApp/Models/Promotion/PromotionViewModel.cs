using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Promotion
{
    public class PromotionViewModel
    {
        public int Id { get; set; }

        public int DiscountPercent { get; set; }

        public string DiscountCode { get; set; }

        public string Description { get; set; }

        public DateTime ExpireTime { get; set; }

        public DateTime StartTime { get; set; }

        public bool IsValid { get; set; }

        public bool IsShow { get; set; }
    }
}
