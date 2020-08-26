using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Victory.Template.WebApp.Controllers.System
{
    public class SystemController : Controller
    {
        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult Log()
        {
            return View();
        }
    }
}
