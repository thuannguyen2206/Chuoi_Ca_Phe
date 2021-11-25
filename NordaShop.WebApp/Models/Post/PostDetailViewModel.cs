using NordaShop.WebApp.Models.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Post
{
    public class PostDetailViewModel
    {
        public PostViewModel Post { get; set; }

        public List<TagViewModel> Tags { get; set; }

        public List<PostViewModel> RelatedPost { get; set; }

        public List<PostCommentViewModel> PostComments { get; set; }
    }
}
