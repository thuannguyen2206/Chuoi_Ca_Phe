using NordaShop.WebApp.Models.Tag;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Post
{
    public class PostIndexViewModel
    {
        public PageResult<List<PostViewModel>> Posts { get; set; }

        public List<TagViewModel> Tags { get; set; }

        public List<PostViewModel> LastestPosts { get; set; }
    }
}
