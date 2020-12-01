using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Common.ViewModel;

namespace MVC.Controllers
{
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpLoad()
        {
            FileCvViewModel model = new FileCvViewModel();
            var file = Request.Form.Files[0];
            var folderName = Path.Combine(@"D:\ERP-Recruiting\Backend\APIGateway\wwwroot/cadidate-cv");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                var fileSize = file.Length / 1024;
                var fileType = Path.GetExtension(fileName);
                
                model.FileName = fileName;
                model.FilePath = fullPath;
                model.FileSize = Convert.ToInt32(fileSize);
                model.FileType = fileType;
                model.DbPath = dbPath;
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return Json(model);
        }
    }
}
