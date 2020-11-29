using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Services.Interfaces;
using Newtonsoft.Json;

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

        public IActionResult Error()
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
        public JsonResult Login([FromBody] LoginViewModel model)
        {
            try
            {
                var response = _cadidateService.Login(model);
                if(response == true)
                {
                    var user = _cadidateService.GetByUsername(model.Username);
                    var userSession = new UserSession();
                    userSession.Username = user.Username;
                    userSession.Image = user.FileName;
                    userSession.Id = user.CadidateId;
                    var session = JsonConvert.SerializeObject(userSession);

                    HttpContext.Session.SetString(Common.CommonSession.USER_SESSION, session);
                }
                return Json(response);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public JsonResult Authen()
        {
            try
            {
                string user = Convert.ToString(HttpContext.Session.GetString(Common.CommonSession.USER_SESSION));
                if(user != null)
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
