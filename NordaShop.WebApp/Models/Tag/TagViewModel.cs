using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Tag
{
    public class TagViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string TagName { get; set; }

        public bool IsActive { get; set; }

        public string SeoAlias { get; set; }
    }
}
