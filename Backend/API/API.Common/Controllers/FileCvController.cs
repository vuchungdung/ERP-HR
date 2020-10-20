using Core.CommonModel;
using Core.Services.InterfaceService;
using Core.Utility;
using Database.Sql.ERP.Entities.Common;
using Microsoft.AspNetCore.Mvc;
using Services.Common.Interfaces;
using Services.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace API.Common.Controllers
{
    [Route("api/common/file")]
    [ApiController]
    public class FileCvController : ControllerBase
    {
        private IFileCvService _fileCvService;
        private ISequenceService _sequenceService;

        public FileCvController(IFileCvService fileCvService, ISequenceService sequenceService)
        {
            _fileCvService = fileCvService;
            _sequenceService = sequenceService;
        }

        [Route("upload")]
        [DisableFormValueModelBinding]
        [HttpPost, DisableRequestSizeLimit]
        public async Task<ResponseModel> Upload()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                FileCvViewModel model = new FileCvViewModel();
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot/cadidate-cv");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if(file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    var fileSize = file.Length / 1024;
                    var fileType = Path.GetExtension(fileName);

                    model.CadidateId = Convert.ToInt32(await _sequenceService.GetCadidateNewId());
                    model.FileName = fileName;
                    model.FilePath = fullPath;
                    model.FileSize = Convert.ToInt32(fileSize);
                    model.FileType = fileType;
                    model.DbPath = dbPath;

                    response.Result = model;

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}
