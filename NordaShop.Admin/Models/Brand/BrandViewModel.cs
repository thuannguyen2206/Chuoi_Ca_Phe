using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Models.Brand
{
    public class BrandViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string BrandLogo { get; set; }

        public IFormFile BrandFile { get; set; }

        [Required(ErrorMessage = "Brand name is required")]
        public string BrandName { get; set; }

        [MaxLength(500, ErrorMessage = "Seo alias too long")]
        public string SeoAlias { get; set; }

        public bool IsActive { get; set; }

        public int TotalProducts { get; set; }

    }
}
