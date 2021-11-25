using Microsoft.AspNetCore.Mvc;
using Service.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Controllers.Components
{
    public class PagerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(PageResultBase resultBase)
        {
            return View("Default", resultBase);
        }
    }
}
