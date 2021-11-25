using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Carts
{
    public class CartDto
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public Guid UserId { get; set; }

        public int TotalProducts { get; set; }

        public List<CartItemDto> CartItems { get; set; }
    }
}
