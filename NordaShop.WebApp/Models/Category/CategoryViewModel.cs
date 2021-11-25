using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Models.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public int MenuId { get; set; }

        public int? ParentId { get; set; }
    }
}
