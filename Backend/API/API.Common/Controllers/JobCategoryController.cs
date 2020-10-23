using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Common.Interfaces;
using Services.Common.ViewModel;
using System.Threading.Tasks;

namespace API.Common.Controllers
{
    [Route("/api/common/jobcategory")]
    [ApiController]
    public class JobCategoryController : ControllerBase
    {
        private IJobCategoryService _jobcategoryService;

        public JobCategoryController(IJobCategoryService jobcategoryService)
        {
            _jobcategoryService = jobcategoryService;
        }

        [HttpGet]
        [Authorize]
        [Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _jobcategoryService.Item(id);
            return response;
        }

        [HttpPost]
        [Authorize]
        [Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] JobCategoryViewModel model)
        {
            var response = await _jobcategoryService.Insert(model);
            return response;
        }

        [HttpPost]
        [Authorize]
        [Route("get-list")]
        public async Task<ResponseModel> GetList([FromBody] FilterModel model)
        {
            var response = await _jobcategoryService.GetList(model);
            return response;
        }

        [HttpPut]
        [Authorize]
        [Route("update")]
        public async Task<ResponseModel> Update([FromBody] JobCategoryViewModel model)
        {
            var response = await _jobcategoryService.Update(model);
            return response;
        }

        [HttpDelete]
        [Authorize]
        [Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] JobCategoryViewModel model)
        {
            var response = await _jobcategoryService.Delete(model);
            return response;
        }

        [Route("dropdown")]
        [HttpGet]
        [Authorize]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _jobcategoryService.DropdowmSelection();
            return response;
        }
    }
}