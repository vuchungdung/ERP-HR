using Core.CommonModel;
using Database.Sql.ERP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Common;
using MVC.Models;
using MVC.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Diagnostics.Eventing.Reader;

namespace MVC.Controllers
{
    public class CadidateUserController : Controller
    {
        private readonly ICadidateUserService _cadidateUserService;

        public CadidateUserController(ICadidateUserService cadidateUserService)
        {
            _cadidateUserService = cadidateUserService;
        }

        [HttpPost]
        public IActionResult Login([FromBody]LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = _cadidateUserService.Login(model);
                    if (response != null)
                    {
                        var user = new UserSession();
                        user.Username = response.UserName;
                        user.UserId = response.UserId;
                        HttpContext.Session.SetString(CommonSession.USER_SESSION, JsonConvert.SerializeObject(user));
                    }
                    return Json(true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return Json(false);
        }
        [HttpPost]
        public IActionResult Register([FromBody]RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = _cadidateUserService.Register(model);
                    return Json(true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return Json(false);
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}