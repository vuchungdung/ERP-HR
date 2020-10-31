using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Services;
using MVC.Services.Interfaces;
using System;

namespace MVC.Controllers
{
    public class JobDescriptionController : Controller
    {
        private readonly IJobDescriptionService _jobDescriptionService;

        public JobDescriptionController(IJobDescriptionService jobDescriptionService)
        {
            _jobDescriptionService = jobDescriptionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetAllPaging(PageViewModel model)
        {
            try
            {
                var response = _jobDescriptionService.GetJobPaging(model);
                return Json(response);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}