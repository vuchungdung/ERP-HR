using Database.Sql.ERP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class CadidateUserController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ERPContext _context;

        public CadidateUserController(ILogger<HomeController> logger, ERPContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
