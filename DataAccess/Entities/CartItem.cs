using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class CartItem : BaseModel
    {
        public int ProductId { get; set; }

        public int CartId { get; set; }

        public int Quantity { get; set; }

        public int SizeOptionId { get; set; }

        public Product Product { get; set; }

        public Cart Cart { get; set; }
    }
}
