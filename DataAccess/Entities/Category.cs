using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Category : BaseModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public string SeoAlias { get; set; }

        public int? ParentId { get; set; }

        public int MenuId { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public int SortOrder { get; set; }

        public List<Product> Products { get; set; }
    }
}
