using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interview.Interfaces;
using Services.Interview.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Interview.Controller
{
    [ApiController]
    [Route("/api/interview/interviewprocess")]
    public class InterviewProcessController : ControllerBase
    {
        private readonly IInterviewProcessService _interviewProcessService;

        public InterviewProcessController(IInterviewProcessService interviewProcessService)
        {
            _interviewProcessService = interviewProcessService;
        }

        [HttpPost]
        [Route("insert")]
        [Authorize]
        public async Task<ResponseModel> Insert([FromForm] InterviewProcessViewModel model)
        {
            if(model.Result == Core.CommonModel.Enum.Result.Fail)
            {
                throw new Exception();
            }
            _interviewProcessService.UpdateStatus(model);
            var response = await _interviewProcessService.Insert(model);
            return response;
        }

        [HttpPost]
        [Route("get-list")]
        [Authorize]
        public async Task<ResponseModel> GetList([FromBody] FilterModel model)
        {
            var response = await _interviewProcessService.GetList(model);
            return response;
        }

        [HttpPut]
        [Route("update")]
        [Authorize]
        public async Task<ResponseModel> Update([FromForm] InterviewProcessViewModel model)
        {
            var response = await _interviewProcessService.Update(model);
            return response;
        }
    }
}
