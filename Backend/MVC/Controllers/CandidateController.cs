using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Aspose.Pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public CandidateController(ICandidateService cadidateService,IFileService fileService)
        {
            _cadidateService = cadidateService;
            _fileService = fileService;
        }

        [TypeFilter(typeof(AuthenController))]
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
                    userSession.Id = user.CandidateId;
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

        public IActionResult GenPDF()
        {
            WebRequest req = WebRequest.Create(@"https://docs.oracle.com/javase/tutorial/networking/urls/readingURL.html");
            // Get web page into stream
            using (Stream stream = req.GetResponse().GetResponseStream())
            {
                // Initialize HTML load options
                HtmlLoadOptions htmloptions = new HtmlLoadOptions("https://docs.oracle.com/");
                // Load stream into Document object
                Document pdfDocument = new Document(stream, htmloptions);
                // Save output as PDF format
                pdfDocument.Save("HTML-to-PDF.pdf");
            }
            return View();
        }
        [HttpGet("download")]
        public IActionResult GetBlobDownload([FromQuery] string link)
        {
            var net = new System.Net.WebClient();
            var data = net.DownloadData(link);
            var content = new System.IO.MemoryStream(data);
            var contentType = "APPLICATION/octet-stream";
            var fileName = "something.bin";
            return File(content, contentType, fileName);
        }

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
                    var folderName = Path.Combine(@"D:\ERP-Recruiting\Backend\APIGateway\wwwroot/candidate-cv");
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
