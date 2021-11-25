using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Models.Menu
{
    public class MenuViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name menu is required")]
        [MaxLength(100, ErrorMessage = "Name too long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Link of menu is required")]
        [MaxLength(100, ErrorMessage = "Link of menu too long")]
        public string Link { get; set; }

        [MaxLength(500, ErrorMessage = "Seo alias too long")]
        public string SeoAlias { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
