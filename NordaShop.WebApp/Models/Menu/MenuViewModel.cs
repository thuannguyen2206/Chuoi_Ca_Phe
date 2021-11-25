﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Menu
{
    public class MenuViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public bool IsActive { get; set; }
    }
}
