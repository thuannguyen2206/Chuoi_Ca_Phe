using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Slide : BaseModel
    {
        public string Name { get; set; }

        public string ImageLink { get; set; }

        public string Title { get; set; }

        public int SortOrder { get; set; }

        public bool IsDelete { get; set; }

        public bool IsActive { get; set; }
    }
}
