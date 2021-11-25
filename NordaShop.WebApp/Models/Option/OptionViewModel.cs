using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Option
{
    public class OptionViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string NameOption { get; set; }

        public ProductOptionGroup OptionGroup { get; set; }

        public bool Checked { get; set; }

        public int ProductQuantity { get; set; }
    }
}
