using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Menus
{
    public class MenuDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public int DisplayOrder { get; set; }

        public string SeoAlias { get; set; }

        public bool IsActive { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
