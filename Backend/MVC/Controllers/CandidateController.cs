using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Aspose.Pdf;
using Core.Services.InterfaceService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MVC.Common;
using MVC.Models;
using MVC.Services.Interfaces;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class CandidateController : Controller
    {
        private readonly ICandidateService _cadidateService;
        private readonly IFileService _fileService;
        private readonly IInterviewProcessService _interviewProcessService;
        private readonly ISequenceService _sequenceService;

        public CandidateController(ICandidateService cadidateService
            , IFileService fileService
            , IInterviewProcessService interviewProcessService
            , ISequenceService sequenceService
            )
        {
            _cadidateService = cadidateService;
            _fileService = fileService;
            _interviewProcessService = interviewProcessService;
            _sequenceService = sequenceService;
        }

        [TypeFilter(typeof(AuthenController))]
        public IActionResult Index()
        {
            return View();
        }

        [TypeFilter(typeof(AuthenController))]
        public IActionResult ManageJob()
        {
            return View();
        }

        [TypeFilter(typeof(AuthenController))]
        public IActionResult GetApplyJob()
        {
            try
            {
                var session = Convert.ToString(HttpContext.Session.GetString(CommonSession.USER_SESSION));
                var user = JsonConvert.DeserializeObject<UserSession>(session);
                var response = _cadidateService.Get(user.Id);
                return Json(response);
            }
            catch(Exception ex)
            {
                throw ex;
            }
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
                    userSession.Id = user.CandidateId;
                    if(_cadidateService.Get(user.CandidateId).Count > 0)
                    {
                        userSession.JobId = _cadidateService.Get(user.CandidateId).ElementAt(0).JobId;
                    }
                    else
                    {
                        userSession.JobId = 0;
                    }
                    userSession.FileName = user.FileName.ToString();
                    userSession.FilePath = user.FilePath.ToString();
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

        public JsonResult LogOut()
        {
            HttpContext.Session.Clear();
            return Json(true);
        }

        [HttpPost]
        public JsonResult Authen([FromBody] int id)
        {
            TempData["JobId"] = id;
            try
            {
                string user = Convert.ToString(HttpContext.Session.GetString(Common.CommonSession.USER_SESSION));
                if (user != null)
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult UpdateProfile(CandidateViewModel model)
        {
            
            try
            {
                var session = Convert.ToString(HttpContext.Session.GetString(CommonSession.USER_SESSION));
                var user = JsonConvert.DeserializeObject<UserSession>(session);
                model.CandidateId = user.Id;
                var response = _cadidateService.CreateProfile(model);
                return Json(response);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [TypeFilter(typeof(AuthenController))]
        public IActionResult GetCandidate()
        {
            try
            {
                var session = Convert.ToString(HttpContext.Session.GetString(CommonSession.USER_SESSION));
                if(session == null)
                {
                    return Json(null);
                }
                else
                {
                    var user = JsonConvert.DeserializeObject<UserSession>(session);
                    var username = user.Id;
                    var response = _cadidateService.GetDetail(username);
                    return Json(response);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult Preview()
        {
            return View();
        }
        public IActionResult Info()
        {
            return View();
        }


        [TypeFilter(typeof(AuthenController))]
        public IActionResult Apply(ApplyViewModel model)
        {
            try
            {
                var session = Convert.ToString(HttpContext.Session.GetString(CommonSession.USER_SESSION));
                var user = JsonConvert.DeserializeObject<UserSession>(session);
                model.CandidateId = user.Id;
                model.JobId = Convert.ToInt32(TempData["JobId"].ToString());
                model.CreateBy = user.Id;
                var response = _cadidateService.Apply(model);
                if(response == true)
                {
                    user.JobId = model.JobId;
                    var s = JsonConvert.SerializeObject(user);
                    HttpContext.Session.SetString(Common.CommonSession.USER_SESSION, s);
                    FileViewModel f = new FileViewModel();
                    var file = model.File;
                    var folderName = Path.Combine(@"D:\ERP-Recruiting\Backend\APIGateway\wwwroot/cadidate-cv");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);
                        var fileSize = file.Length / 1024;
                        var fileType = Path.GetExtension(fileName);

                        f.FileName = fileName;
                        f.FilePath = fullPath;
                        f.FileSize = Convert.ToInt32(fileSize);
                        f.FileType = fileType;
                        f.CandidateId = user.Id;
                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        _fileService.Create(f);
                    }
                    InterviewProcessViewModel i = new InterviewProcessViewModel();
                    i.ApplyId = _sequenceService.GetApplyNewId();
                    i.CreateBy = user.Id;
                    i.ProcessId = 1;
                    _interviewProcessService.Create(i);
                }
                return Json(true);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }
}
