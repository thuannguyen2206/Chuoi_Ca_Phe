using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.WebApp.Controllers.Components
{
    public class BreadcrumbViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string pagename)
        {
            if (string.IsNullOrEmpty(pagename))
            {
                pagename = "Not Found";
            }
            return View("Default", pagename);
        }
    }
}
