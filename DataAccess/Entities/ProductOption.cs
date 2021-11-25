using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class ProductOption
    {
        public int ProductId { get; set; }

        public int OptionId { get; set; }

        public bool IsDefault { get; set; }

        public Product Product { get; set; }

        public Option Option { get; set; }
    }
}
