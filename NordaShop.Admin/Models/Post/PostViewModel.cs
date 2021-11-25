using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Models.Post
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        //public Guid OwnerId { get; set; }

        public int ViewCount { get; set; }

        public int TotalComment { get; set; }

        public string ReviewContent { get; set; }

        public string Title { get; set; }

        public string SeoAlias { get; set; }

        public string LinkImage { get; set; }

        public bool IsActive { get; set; }
    }
}
