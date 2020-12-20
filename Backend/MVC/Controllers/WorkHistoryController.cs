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
    public class WorkHistoryController : Controller
    {
        private readonly IWorkHistoryService _service;

        public WorkHistoryController(IWorkHistoryService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create([FromBody] WorkHistoryViewModel model)
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

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
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
    }
}
