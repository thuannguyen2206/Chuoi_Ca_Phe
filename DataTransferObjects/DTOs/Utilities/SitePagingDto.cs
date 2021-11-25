using Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Utilities
{
    public class SitePagingDto : PagingDto
    {
        public int? CategoryId { get; set; }

        public int? TagId { get; set; }

        public SortProduct SortProduct { get; set; }

        public decimal FromPrice { get; set; }

        public decimal ToPrice { get; set; }

        public int[] Options { get; set; }

        public int[] Brands { get; set; }
    }
}
