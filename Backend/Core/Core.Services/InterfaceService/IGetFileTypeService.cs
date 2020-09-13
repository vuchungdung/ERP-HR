using Core.CommonModel.Enum;
using Database.Sql.ERP.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.InterfaceService
{
    public interface IGetFileTypeService
    {
        Task<File> GetFileType(string cadidateId, FileType fileType);
    }
}
