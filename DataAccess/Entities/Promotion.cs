using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Promotion : BaseModel
    {
        public int DiscountPercent { get; set; }

        public string DiscountCode { get; set; }

        public string Description { get; set; }

        public DateTime ExpireTime { get; set; }

        public DateTime StartTime { get; set; }

        public bool IsValid { get; set; }

        public decimal? MaxValueDiscount { get; set; } // Currency

        public bool IsShow { get; set; }
    }
}
