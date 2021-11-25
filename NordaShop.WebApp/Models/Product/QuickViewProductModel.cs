using NordaShop.WebApp.Models.Option;
using NordaShop.WebApp.Models.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Product
{
    public class QuickViewProductModel
    {
        public ProductViewModel Product { get; set; }

        public List<OptionViewModel> Options { get; set; }

        public List<TagViewModel> Tags { get; set; }

        public List<RelatedColorViewModel> RelatedColors { get; set; }
    }
}
