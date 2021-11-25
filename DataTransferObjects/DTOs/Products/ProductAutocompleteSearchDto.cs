using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Products
{
    public class ProductAutocompleteSearchDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DefaultImage { get; set; }

        public string SeoAlias { get; set; }
    }
}
