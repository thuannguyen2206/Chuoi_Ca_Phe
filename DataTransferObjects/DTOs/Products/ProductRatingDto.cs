using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Products
{
    public class ProductRatingDto
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string RatingContent { get; set; }

        public int RatingStar { get; set; }

        public int ProductId { get; set; }
    }
}
