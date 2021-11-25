using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class TagInProduct
    {
        public int ProductId { get; set; }

        public int TagId { get; set; }

        public Product Product { get; set; }

        public Tag Tag { get; set; }
    }
}
