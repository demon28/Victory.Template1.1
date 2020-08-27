using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Victory.Template.WebApp.Controllers
{
    [Authorize]
    public class SystemController : Controller
    {
     
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult NoPermission()
        {
            return View();
        }
    }
}
