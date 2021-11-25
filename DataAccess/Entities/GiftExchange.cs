using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class GiftExchange : BaseModel
    {
        public int ProductId { get; set; }

        public int RedemptionPoints { get; set; } // điểm đổi thưởng

        public bool IsActive { get; set; }

        public bool InStock { get; set; } // true: còn hàng - false: hết hàng

        public string Description { get; set; }
    }
}
