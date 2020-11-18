using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Recruitment.Interface;
using Services.Recruitment.ViewModel;
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

        [HttpPost]
        [Route("insert")]
        [Authorize]
        public async Task<ResponseModel> Insert([FromForm] JobDescriptionViewModel model)
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
        public async Task<ResponseModel> Update([FromForm] JobDescriptionViewModel model)
        {
            var response = await _jobDescriptionService.Update(model);
            return response;
        }

        [Route("delete")]
        [HttpDelete]
        [Authorize]
        public async Task<ResponseModel> Delete([FromQuery] int id)
        {
            var response = await _jobDescriptionService.Delete(id);
            return response;
        }

        [Route("item")]
        [HttpGet]
        [Authorize]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _jobDescriptionService.Item(id);
            return response;
        }
    }
}