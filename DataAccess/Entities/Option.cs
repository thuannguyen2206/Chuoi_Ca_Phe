using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Option : BaseModel
    {
        public string NameOption { get; set; }

        public ProductOptionGroup OptionGroup { get; set; }

        public string SeoAlias { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public List<ProductOption> ProductOptions { get; set; }
    }
}
