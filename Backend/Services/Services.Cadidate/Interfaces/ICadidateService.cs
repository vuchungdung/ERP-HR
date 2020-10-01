using Core.CommonModel;
using Core.Services.InterfaceService;
using Microsoft.AspNetCore.Http;
using Services.Cadidates.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Cadidates.Interfaces
{
    public interface ICadidateService : IBaseInterfaceService<CadidateViewModel>
    {
        Task<ResponseModel> DropdownSelection();
        Task<ResponseModel> ApplyToJob(int id);
        Task<ResponseModel> ChangeProcess(int id, int processId);
        Task<ResponseModel> Tagging(int id,int tagId);
    }
}
