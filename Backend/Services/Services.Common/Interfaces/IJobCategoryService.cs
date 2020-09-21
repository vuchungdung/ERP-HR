using Core.CommonModel;
using Core.Services.InterfaceService;
using Database.Sql.ERP.Entities.Common;
using Services.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Interfaces
{
    public interface IJobCategoryService : IBaseInterfaceService<JobCategoryViewModel>
    {
        Task<ResponseModel> DropdowmSelection();
    }
}
