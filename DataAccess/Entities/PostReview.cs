using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class PostReview : BaseModel
    {
        public Guid OwnerId { get; set; }

        public int ViewCount { get; set; }

        public string ReviewContent { get; set; }

        public string Title { get; set; }

        public string SeoAlias { get; set; }

        public string LinkImage { get; set; }

        public bool IsActive { get; set; }

        public List<PostComment> PostComments { get; set; }

        public List<TagInPost> TagInPosts { get; set; }
    }
}
