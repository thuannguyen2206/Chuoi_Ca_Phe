using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Carts
{
    public class AddCartItemDto
    {
        public Guid UserId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public int SizeId { get; set; }
    }
}
