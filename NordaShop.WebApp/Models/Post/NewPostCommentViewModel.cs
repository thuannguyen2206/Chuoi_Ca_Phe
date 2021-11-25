using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Post
{
    public class NewPostCommentViewModel
    {
        public int PostId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name too long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(100, ErrorMessage = "Email too long")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }
    }
}
