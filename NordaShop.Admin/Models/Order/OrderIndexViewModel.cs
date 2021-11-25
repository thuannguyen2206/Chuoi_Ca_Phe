using DataAccess.Enums;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Models.Order
{
    public class OrderIndexViewModel
    {
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public string Keyword { get; set; }

        public OrderStatus? OrderStatus { get; set; }

        public PageResult<List<OrderInfoViewModel>> Orders { get; set; }
    }
}
