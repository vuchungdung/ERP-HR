using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Common;
using MVC.Models;
using MVC.Services.Interfaces;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class EducationController : Controller
    {
        private readonly IEducationService _service;

        public EducationController(IEducationService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(EducationViewModel model)
        {
            var session = Convert.ToString(HttpContext.Session.GetString(CommonSession.USER_SESSION));
            try
            {
                var user = JsonConvert.DeserializeObject<UserSession>(session);
                model.CandidateId = user.Id;
                model.CreateBy = user.Id;
                var response = _service.Create(model);
                return Json(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Update(EducationViewModel model)
        {
            var session = Convert.ToString(HttpContext.Session.GetString(CommonSession.USER_SESSION));
            try
            {
                var user = JsonConvert.DeserializeObject<UserSession>(session);
                model.CandidateId = user.Id;
                model.UpdateBy = user.Id;
                var response = _service.Update(model);
                return Json(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var response = _service.Delete(id);
                return Json(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult Get()
        {
            var session = Convert.ToString(HttpContext.Session.GetString(CommonSession.USER_SESSION));
            try
            {
                var user = JsonConvert.DeserializeObject<UserSession>(session);
                var response = _service.GetByCId(user.Id);
                return Json(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IActionResult GetId(int id)
        {
            try
            {
                var response = _service.GetById(id);
                return Json(response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
