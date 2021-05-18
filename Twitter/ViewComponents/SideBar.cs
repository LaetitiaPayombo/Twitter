using Twitter.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter.ViewComponents
{
    public class SideBar : ViewComponent
    {

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.Classements = Classement.GetClassements();
            return View();
        }

    }
}
