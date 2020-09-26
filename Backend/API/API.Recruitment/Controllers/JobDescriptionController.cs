using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Recruitment.Interface;
using Services.Recruitment.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Recruitment.Controllers
{
    [ApiController]
    [Route("/api/recruitment/jobdescription")]
    public class JobDescriptionController : ControllerBase
    {
        private IJobDescriptionService _jobDescriptionService;

        public JobDescriptionController(IJobDescriptionService jobDescriptionService)
        {
            _jobDescriptionService = jobDescriptionService;
        }

        [Route("insert")]
        [HttpPost]
        [Authorize]
        public async Task<ResponseModel> Insert([FromBody] JobDescriptionViewModel model)
        {
            var response = await _jobDescriptionService.Insert(model);
            return response;
        }

        [Route("get-list")]
        [HttpPost]
        [Authorize]
        public async Task<ResponseModel> GetList([FromBody] FilterModel model)
        {
            var response = await _jobDescriptionService.GetList(model);
            return response;
        }
        [Route("update")]
        [HttpPut]
        [Authorize]
        public async Task<ResponseModel> Update([FromBody] JobDescriptionViewModel model)
        {
            var response = await _jobDescriptionService.Update(model);
            return response;
        }
        [Route("delete")]
        [HttpDelete]
        [Authorize]
        public async Task<ResponseModel> Delete([FromBody] JobDescriptionViewModel model)
        {
            var response = await _jobDescriptionService.Delete(model);
            return response;
        }
    }
}
