using Core.CommonModel;
using Core.Services.InterfaceService;
using Services.System.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.System.Interfaces
{
    public interface IRoleService : IBaseInterfaceService<RoleViewModel>
    {
        Task<ResponseModel> DropdownSelection();
    }
}
