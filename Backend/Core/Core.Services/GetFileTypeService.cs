using Core.CommonModel.Enum;
using Core.Services.InterfaceService;
using Database.Sql.ERP.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class GetFileTypeService : IGetFileTypeService
    {
        public Task<File> GetFileType(string cadidateId, FileType fileType)
        {
            throw new NotImplementedException();
        }
    }
}
