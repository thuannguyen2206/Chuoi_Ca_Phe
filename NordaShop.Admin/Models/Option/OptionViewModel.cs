using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Models.Option
{
    public class OptionViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Name option is required")]
        public string NameOption { get; set; }

        [MaxLength(500, ErrorMessage = "Seo alias too long")]
        public string SeoAlias { get; set; }

        public ProductOptionGroup OptionGroup { get; set; }

        public bool IsActive { get; set; }

        public int ProductQuantity { get; set; }

        public bool Checked { get; set; }

        public string GroupName { get; set; }
    }
}
