using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Posts
{
    public class PostDto
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public Guid OwnerId { get; set; }

        public string ReviewContent { get; set; }

        public string Title { get; set; }

        public string SeoAlias { get; set; }

        public string LinkImage { get; set; }

        public bool IsActive { get; set; }

        public int TotalComment { get; set; }

        public int ViewCount { get; set; }

        public int? NextId { get; set; }

        public string NextSeoAlias { get; set; }

        public int? PreviousId { get; set; }

        public string PreviousSeoAlias { get; set; }
    }
}
