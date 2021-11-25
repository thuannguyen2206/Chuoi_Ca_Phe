using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Options
{
    public class RelatedColorDto
    {
        public int ColorId { get; set; }

        public string ColorName { get; set; }

        public int ProductId { get; set; }

        public string CodeProduct { get; set; }

        public string SeoAlias { get; set; }
    }
}
