using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Brand : BaseModel
    {
        public string BrandName { get; set; }

        public string BrandLogo { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public string SeoAlias { get; set; }

        public List<Product> Products { get; set; }
    }
}
