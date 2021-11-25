using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Utilities
{
    public class OrderAdminPagingDto : PagingDto
    {
        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public OrderStatus? OrderStatus { get; set; }
    }
}
