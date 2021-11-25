using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Models.Slide
{
    public class CESlideViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name too long")]
        public string Name { get; set; }

        public IFormFile ImageFile { get; set; }

        [MaxLength(200, ErrorMessage = "Title too long")]
        public string Title { get; set; }

        public int SortOrder { get; set; }

        public bool IsActive { get; set; }
    }
}
