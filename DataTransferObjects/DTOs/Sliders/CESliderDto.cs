using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Sliders
{
    public class CESliderDto // create and edit slide
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IFormFile ImageFile { get; set; }

        public string Title { get; set; }

        public int SortOrder { get; set; }

        public bool IsActive { get; set; }
    }
}
