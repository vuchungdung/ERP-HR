using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Services.Recruitment.Interface;
using Services.Recruitment.ViewModel;
using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace API.Recruitment.Controllers
{
    [ApiController]
    [Route("/api/recruitment/plan")]
    public class RecruitmentPlanController : ControllerBase
    {
        private IRecruitmentPlanService _recruitmentPlanService;

        public RecruitmentPlanController(IRecruitmentPlanService recruitmentPlanService)
        {
            _recruitmentPlanService = recruitmentPlanService;
        }

        [HttpGet]
        [Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel model)
        {
            var response = await _recruitmentPlanService.GetList(model);
            return response;
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ResponseModel> Delete(RecruitmentPlanViewModel model)
        {
            var response = await _recruitmentPlanService.Delete(model);
            return response;
        }

        [HttpGet]
        [Route("item")]
        public async Task<ResponseModel> Item(int id)
        {
            var response = await _recruitmentPlanService.Item(id);
            return response;
        }

        [HttpPost]
        [Route("insert")]
        public async Task<ResponseModel> Insert(RecruitmentPlanViewModel model)
        {
            var response = await _recruitmentPlanService.Insert(model);
            return response;
        }

        [HttpPut]
        [Route("update")]
        public async Task<ResponseModel> Update(RecruitmentPlanViewModel model)
        {
            var response = await _recruitmentPlanService.Update(model);
            return response;
        }
    }
}
