using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Brands
{
    public class BrandDto
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string BrandLogo { get; set; }

        public IFormFile BrandFile { get; set; }

        public string BrandName { get; set; }

        public string SeoAlias { get; set; }

        public bool IsActive { get; set; }

        public int TotalProducts { get; set; }
    }
}
