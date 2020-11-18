using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Common.Interfaces;
using Services.Common.ViewModel;
using System.Threading.Tasks;

namespace API.Common.Controllers
{
    [Route("/api/common/process")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private IProcessService _processService;

        public ProcessController(IProcessService processService)
        {
            _processService = processService;
        }

        [HttpGet]
        [Authorize]
        [Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _processService.Item(id);
            return response;
        }

        [HttpPost]
        [Authorize]
        [Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] ProcessViewModel model)
        {
            var response = await _processService.Insert(model);
            return response;
        }

        [HttpPost]
        [Authorize]
        [Route("get-list")]
        public async Task<ResponseModel> GetList([FromBody] FilterModel model)
        {
            var response = await _processService.GetList(model);
            return response;
        }

        [HttpPut]
        [Authorize]
        [Route("update")]
        public async Task<ResponseModel> Update([FromBody] ProcessViewModel model)
        {
            var response = await _processService.Update(model);
            return response;
        }

        [HttpDelete]
        [Authorize]
        [Route("delete")]
        public async Task<ResponseModel> Delete([FromQuery] int id)
        {
            var response = await _processService.Delete(id);
            return response;
        }
    }
}