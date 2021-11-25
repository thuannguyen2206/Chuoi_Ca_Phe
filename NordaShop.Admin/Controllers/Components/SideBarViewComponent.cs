using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordaShop.Admin.Controllers.Components
{
    public class SideBarViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View("Default");
        }
    }
}
