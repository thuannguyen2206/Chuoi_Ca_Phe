using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class ProductDetail : BaseModel
    {
        public int ProductId { get; set; }

        public string SeoDescription { get; set; }

        public string SeoTitle { get; set; }

        public string SeoAlias { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Product Product { get; set; }
    }
}
