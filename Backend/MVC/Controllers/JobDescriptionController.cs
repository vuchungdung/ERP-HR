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
            
            if(TempData["keyword"] != null && TempData["categoryId"]!= null)
            {
                model.Keyword = TempData["keyword"].ToString();
                model.Categoryid = Convert.ToInt32(TempData["categoryId"]);
            }
            else
            {
                model.Categoryid = 0;
            }
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

        public JsonResult SimilarJob()
        {
            int categoriId = Convert.ToInt32(TempData["similarId"]);
            try
            {
                var response = _jobDescriptionService.GetSimilar(categoriId);
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

        public JsonResult Detail()
        {
            int id = Convert.ToInt32(TempData["jobId"]);
            try
            {
                var response = _jobDescriptionService.GetDetail(id);
                TempData["similarId"] = response.CategoryId;
                return Json(response);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult Item([FromQuery]int id)
        {
            TempData["jobId"] = id;
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