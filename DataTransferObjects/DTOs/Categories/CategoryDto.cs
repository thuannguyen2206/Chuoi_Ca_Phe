using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Categories
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public string SeoAlias { get; set; }

        public int? ParentId { get; set; }

        public int MenuId { get; set; }

        public string MenuName { get; set; }

        public bool IsActive { get; set; }

        public int SortOrder { get; set; }
    }
}
