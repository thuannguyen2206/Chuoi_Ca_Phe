using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Tags
{
    public class TagDto
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string TagName { get; set; }

        public bool IsActive { get; set; }

        public string SeoAlias { get; set; }
    }
}
