using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Services.Interfaces;

namespace MVC.Controllers
{
    public class CadidateController : Controller
    {
        private readonly ICadidateService _cadidateService;

        public CadidateController(ICadidateService cadidateService)
        {
            _cadidateService = cadidateService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Register([FromBody]RegisterViewModel model)
        {
            try
            {
                var response = _cadidateService.Regrister(model);
                return Json(response);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
