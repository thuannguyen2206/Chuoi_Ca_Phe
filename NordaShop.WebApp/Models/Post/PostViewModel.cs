using NordaShop.WebApp.Models.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Post
{
    public class PostViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }
        
        public int TotalComment { get; set; }

        public string ReviewContent { get; set; }

        public string Title { get; set; }

        public string SortTitle 
        {
            get
            {
                if (!string.IsNullOrEmpty(this.Title) && this.Title.Length > 20)
                {
                    return string.Format("{0}...", this.Title.Substring(0, 20));
                }
                return this.Title;
            }
        }

        public string SeoAlias { get; set; }

        public string LinkImage { get; set; }

        public int? NextId { get; set; }

        public string NextSeoAlias { get; set; }

        public int? PreviousId { get; set; }

        public string PreviousSeoAlias { get; set; }
    }
}
