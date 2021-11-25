using Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Utilities
{
    public class ProductAdminPagingDto : PagingDto
    {
        public int? CategoryId { get; set; }

        public int? BrandId { get; set; }
    }
}
