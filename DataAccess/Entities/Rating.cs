using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Rating : BaseModel
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string RatingContent { get; set; }

        public int RatingStar { get; set; }

        public int ProductId { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }
    }
}
