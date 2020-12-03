using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Common;
using MVC.Models;
using MVC.Services.Interfaces;
using Newtonsoft.Json;
using Services.Common.ViewModel;

namespace MVC.Controllers
{
    public class CadidateController : Controller
    {
        private readonly ICadidateService _cadidateService;
        private readonly IFileService _fileService;
        public CadidateController(ICadidateService cadidateService,IFileService fileService)
        {
            _cadidateService = cadidateService;
            _fileService = fileService;
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
        public JsonResult Login([FromBody]LoginViewModel model)
        {
            try
            {
                var response = _cadidateService.Login(model);
                if(response == true)
                {
                    var user = _cadidateService.GetByUsername(model.Username);
                    var userSession = new UserSession();
                    userSession.Username = user.Username;
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
        [HttpPost]
        public JsonResult Authen([FromBody]int id)
        {
            TempData["JobId"] = id;
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
        public JsonResult LogOut()
        {
            HttpContext.Session.Clear();
            return Json(true);
        }

        public IActionResult UpdateProfile(CadidateViewModel model)
        {
            
            try
            {
                var session = Convert.ToString(HttpContext.Session.GetString(CommonSession.USER_SESSION));
                var user = JsonConvert.DeserializeObject<UserSession>(session);
                model.CadidateId = user.Id;
                model.JobId = Convert.ToInt32(TempData["JobId"]);
                var response = _cadidateService.CreateProfile(model);
                if(response == true)
                {
                    foreach (var item in model.Files)
                    {
                        FileViewModel file = new FileViewModel();
                        var folderName = Path.Combine(@"D:\ERP-Recruiting\Backend\APIGateway\wwwroot/cadidate-cv");
                        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                        if (item.Length > 0)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');
                            var fullPath = Path.Combine(pathToSave, fileName);
                            var dbPath = Path.Combine(folderName, fileName);
                            var fileSize = item.Length / 1024;
                            var fileType = Path.GetExtension(fileName);

                            file.CadidateId = user.Id;
                            file.FileName = fileName;
                            file.FilePath = fullPath;
                            file.FileSize = Convert.ToInt32(fileSize);
                            file.FileType = fileType;
                        }
                        _fileService.Create(file);
                    }
                    return Json(true);
                }
                return Json(false);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult GetCadidate()
        {
            try
            {
                var session = Convert.ToString(HttpContext.Session.GetString(CommonSession.USER_SESSION));
                var user = JsonConvert.DeserializeObject<UserSession>(session);
                var username = user.Username;
                var response = _cadidateService.GetByUsername(username);
                return Json(response);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
