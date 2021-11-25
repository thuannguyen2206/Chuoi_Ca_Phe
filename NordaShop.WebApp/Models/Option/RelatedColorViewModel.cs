﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Option
{
    public class RelatedColorViewModel
    {
        public int ColorId { get; set; }

        public string ColorName { get; set; }

        public int ProductId { get; set; }

        public string CodeProduct { get; set; }

        public string SeoAlias { get; set; }
    }
}
