using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    [TypeFilter(typeof(AuthenController))]
    public class ApplyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
