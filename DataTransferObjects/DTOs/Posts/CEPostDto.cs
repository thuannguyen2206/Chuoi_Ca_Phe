using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Posts
{
    public class CEPostDto
    {
        //public Guid OwnerId { get; set; }

        public string ReviewContent { get; set; }

        public string Title { get; set; }

        public string SeoAlias { get; set; }

        public IFormFile ImageFile { get; set; }

        public bool IsActive { get; set; }

        public int[] Tags { get; set; }

    }
}
