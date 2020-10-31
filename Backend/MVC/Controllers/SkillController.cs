using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC.Services.Interfaces;

namespace MVC.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetAll()
        {
            try
            {
                var response = _skillService.GetAllSkill();
                return Json(response);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
