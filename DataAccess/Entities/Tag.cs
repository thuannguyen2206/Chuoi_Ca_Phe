using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Tag : BaseModel
    {
        public string TagName { get; set; }

        public bool IsActive { get; set; }

        public string SeoAlias { get; set; }

        public List<TagInProduct> TagInProducts { get; set; }

        public List<TagInPost> TagInPosts { get; set; }
    }
}
