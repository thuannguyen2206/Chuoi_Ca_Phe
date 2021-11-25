using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Slide
{
    public class SlideViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageLink { get; set; }

        public string Title { get; set; }

        public int SortOrder { get; set; }
    }
}
