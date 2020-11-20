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

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetAllPaging([FromBody]PageViewModel model)
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

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var response = _jobDescriptionService.GetAll();
                return Json(response);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public IActionResult GetAllNew()
        {
            try
            {
                var response = _jobDescriptionService.GetAllNew();
                return Json(response);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public IActionResult Item(int id)
        {
            try
            {
                var response = _jobDescriptionService.GetDetail(id);
                return Json(response);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Item()
        {
            return View();
        }
    }
}