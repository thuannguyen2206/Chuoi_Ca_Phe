using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Utilities
{
    public class BlogPagingDto : PagingDto
    {
        public int? TagId { get; set; }
    }
}
