using DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Options
{
    public class OptionDto
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string NameOption { get; set; }

        public string SeoAlias { get; set; }

        public ProductOptionGroup OptionGroup { get; set; }

        public bool IsActive { get; set; }

        public int ProductQuantity { get; set; }
    }
}
