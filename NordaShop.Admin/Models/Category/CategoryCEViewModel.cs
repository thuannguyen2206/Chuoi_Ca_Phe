using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Models.Category
{
    public class CategoryCEViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [MaxLength(100, ErrorMessage = "Category name too long")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "Description too long")]
        public string Description { get; set; }

        [MaxLength(100, ErrorMessage = "Title too long")]
        public string Title { get; set; }

        [MaxLength(500, ErrorMessage = "Seo alias too long")]
        public string SeoAlias { get; set; }

        public int? ParentId { get; set; }

        public int MenuId { get; set; }

        public bool IsActive { get; set; }

        public int SortOrder { get; set; }
    }
}
