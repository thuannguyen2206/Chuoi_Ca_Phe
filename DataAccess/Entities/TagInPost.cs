using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class TagInPost
    {
        public int TagId { get; set; }

        public int PostId { get; set; }

        public Tag Tag { get; set; }

        public PostReview PostReview { get; set; }
    }
}
