using MVC.Helper;
using MVC.Models;
using MVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Services
{
    public class FileService : IFileService
    {
        private readonly IDatabaseHelper _helper;

        public FileService(IDatabaseHelper helper)
        {
            _helper = helper;
        }

        public bool Create(FileViewModel model)
        {
            try
            {
                var response = _helper.ExecuteSProcedure("SP_FILE_CREATE", "@CREATEDATE",DateTime.Now, "@DELETED",false, "@FILENAME",model.FileName, "@FILEPATH",model.FilePath, "@FILETYPE",model.FileType, "@FILESIZE",model.FileSize, "@CADIDATEID",model.CandidateId);
                if(response != null)
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
