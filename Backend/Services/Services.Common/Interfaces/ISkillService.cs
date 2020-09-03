using Core.CommonModel;
using Core.Services.InterfaceService;
using Services.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Common.Interfaces
{
    public interface ISkillService : IBaseInterfaceService<SkillViewModel>
    {
        Task<ResponseModel> DropDownSelection();
    }
}
