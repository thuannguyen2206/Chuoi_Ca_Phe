using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class PostComment : BaseModel
    {
        public string Comment { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string SeoAlias { get; set; }

        public string ImageLink { get; set; }

        public int PostId { get; set; }

        public int? ReplyFor { get; set; } // reply for comment id

        public PostReview PostReview { get; set; }
    }
}
