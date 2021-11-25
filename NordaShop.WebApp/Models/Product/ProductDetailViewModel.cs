using NordaShop.WebApp.Models.Option;
using NordaShop.WebApp.Models.Tag;
using System.Collections.Generic;

namespace NordaShop.WebApp.Models.Product
{
    public class ProductDetailViewModel
    {
        public List<ProductViewModel> RelatedProducts { get; set; }

        public ProductViewModel Product { get; set; }

        public List<OptionViewModel> Options { get; set; }

        public List<TagViewModel> Tags { get; set; }

        public List<RelatedColorViewModel> RelatedColors { get; set; }

        public List<ProductRatingViewModel> ProductRatings { get; set; }
    }
}
