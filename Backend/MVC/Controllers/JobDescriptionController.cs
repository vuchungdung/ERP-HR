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

        [HttpPost]
        public IActionResult GetAllPaging([FromBody]PageViewModel model)
        {
            model.Categoryid = Convert.ToInt32(TempData["categoryId"]);
            model.Keyword = TempData["keyword"].ToString();
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
            catch (Exception ex)
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

        public IActionResult Item()
        {
            int id = Convert.ToInt32(TempData["JobId"]);
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

        public IActionResult Item(int id)
        {
            TempData["JobId"] = id;
            return View();
        }

        public IActionResult Items(string keyword, int categoryId = 0)
        {
            if (!String.IsNullOrEmpty(keyword))
            {
                TempData["keyword"] = keyword;
            }
            else
            {
                TempData["keyword"] = "";

            }
            TempData["categoryId"] = categoryId;
            return View();
        }       
    }
}