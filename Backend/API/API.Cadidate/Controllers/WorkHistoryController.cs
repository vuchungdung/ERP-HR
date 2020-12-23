using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Services.Candidates.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Candidate.Controllers
{
    [Route("/api/candidate/workhistory")]
    [ApiController]
    public class WorkHistoryController : ControllerBase
    {
        private readonly IWorkHistoryService _workHistoryService;

        public WorkHistoryController(IWorkHistoryService workHistoryService)
        {
            _workHistoryService = workHistoryService;
        }

        public async Task<ResponseModel> GetList(FilterModel model)
        {
            var response = await _workHistoryService.GetList(model);
            return response;
        }
    }
}
