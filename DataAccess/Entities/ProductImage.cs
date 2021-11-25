using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class ProductImage : BaseModel
    {
        public int ProductId { get; set; }

        public string ImageLink { get; set; }

        public bool IsDefault { get; set; }

        public Product Product { get; set; }
    }
}
