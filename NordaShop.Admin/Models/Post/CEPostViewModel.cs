using Microsoft.AspNetCore.Http;
using NordaShop.Admin.Models.Tag;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Models.Post
{
    public class CEPostViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Content of post is required")]
        public string ReviewContent { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(100, ErrorMessage = "Title too long")]
        public string Title { get; set; }

        public string SeoAlias { get; set; }

        public IFormFile ImageFile { get; set; }

        public bool IsActive { get; set; }

        public List<TagViewModel> Tags { get; set; }
    }
}
