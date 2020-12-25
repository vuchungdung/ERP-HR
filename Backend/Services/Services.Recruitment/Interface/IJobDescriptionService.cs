using Core.CommonModel;
using Core.Services.InterfaceService;
using Services.Recruitment.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Recruitment.Interface
{
    public interface IJobDescriptionService : IBaseInterfaceService<JobDescriptionViewModel>
    {
        Task<ResponseModel> Dropdown();
    }
}
