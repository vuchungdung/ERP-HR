using Core.CommonModel;
using Core.Services.InterfaceService;
using Database.Sql.ERP.Entities.Common;
using Microsoft.AspNetCore.Http;
using Services.Candidates.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Candidates.Interfaces
{
    public interface ICandidateService : IBaseInterfaceService<CandidateViewModel>
    {
        Task<ResponseModel> DropdownSelection();
        Task<ResponseModel> ApplyToJob(int id);
        Task<ResponseModel> ChangeProcess(int id, int processId);
        Task<ResponseModel> Tagging(int id,int tagId);
    }
}
