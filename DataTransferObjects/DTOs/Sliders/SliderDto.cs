﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Sliders
{
    public class SliderDto
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string Name { get; set; }

        public string ImageLink { get; set; }

        public string Title { get; set; }

        public int SortOrder { get; set; }

        public bool IsActive { get; set; }
    }
}
