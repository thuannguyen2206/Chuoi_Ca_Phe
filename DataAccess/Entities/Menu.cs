using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Menu : BaseModel
    {
        public string Name { get; set; }

        public string Link { get; set; }

        public int DisplayOrder { get; set; }

        public string SeoAlias { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public MenuType MenuType { get; set; }
    }
}
