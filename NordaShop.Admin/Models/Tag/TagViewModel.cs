using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Models.Tag
{
    public class TagViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Tag name is required")]
        [MaxLength(100, ErrorMessage = "Tag name too long")]
        public string TagName { get; set; }

        public bool IsActive { get; set; }

        [MaxLength(500, ErrorMessage = "Seo alias too long")]
        public string SeoAlias { get; set; }

        public bool Checked { get; set; }
    }
}
