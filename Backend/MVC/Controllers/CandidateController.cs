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
using Services.Common.ViewModel;

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
                    userSession.JobId = user.JobId;
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
    }
}
