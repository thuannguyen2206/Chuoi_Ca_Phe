using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Product
{
    public class ProductRatingViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public Guid UserId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name too long")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [MaxLength(100, ErrorMessage = "Email too long")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Message is required")]
        public string RatingContent { get; set; }

        public int RatingStar { get; set; }

        public int ProductId { get; set; }

    }
}
