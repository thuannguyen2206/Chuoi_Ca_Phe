using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.DTOs.Utilities
{
    public class PagingDto
    {
        private int _pageSize = 12;

        private int _maxPageSize = 50;

        private int _pageIndex = 1;

        public string Keyword { get; set; }

        public int PageIndex
        {
            get { return _pageIndex; }
            set { _pageIndex = (value < 1) ? 1 : value; }
        }

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value <= 0 || value > _maxPageSize ? _pageSize : value; }
        }
    }
}
