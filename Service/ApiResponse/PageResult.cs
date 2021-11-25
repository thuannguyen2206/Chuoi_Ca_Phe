using System;
using System.Collections.Generic;
using System.Text;

namespace Service.ApiResponse
{
    public class PageResult<T> : PageResultBase
    {
        public T Items { get; set; }
    }
}
