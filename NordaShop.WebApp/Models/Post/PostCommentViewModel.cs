using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Post
{
    public class PostCommentViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Comment { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string SeoAlias { get; set; }

        public string ImageLink { get; set; }

        public int PostId { get; set; }

        public int? ReplyFor { get; set; } // reply for comment id
    }
}
