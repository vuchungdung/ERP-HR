using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.System.Interfaces
{
    public interface IPermissionService
    {
        Task<ResponseModel> GetPermissionScreen();
    }
}
