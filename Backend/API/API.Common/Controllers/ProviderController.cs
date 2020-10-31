using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Common.Interfaces;
using Services.Common.ViewModel;
using System.Threading.Tasks;

namespace API.Common.Controllers
{
    [ApiController]
    [Route("/api/common/provider")]
    [Authorize]
    public class ProviderController : ControllerBase
    {
        private IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        [Route("insert")]
        [HttpPost]
        [Authorize]
        public async Task<ResponseModel> Insert([FromBody] ProviderViewModel model)
        {
            var response = await _providerService.Insert(model);
            return response;
        }

        [Route("get-list")]
        [HttpPost]
        [Authorize]
        public async Task<ResponseModel> GetList([FromBody] FilterModel model)
        {
            var response = await _providerService.GetList(model);
            return response;
        }

        [Route("update")]
        [HttpPut]
        [Authorize]
        public async Task<ResponseModel> Update([FromBody] ProviderViewModel model)
        {
            var response = await _providerService.Update(model);
            return response;
        }

        [Route("delete")]
        [HttpDelete]
        [Authorize]
        public async Task<ResponseModel> Delete([FromBody] ProviderViewModel model)
        {
            var response = await _providerService.Delete(model);
            return response;
        }

        [Route("item")]
        [HttpDelete]
        [Authorize]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _providerService.Item(id);
            return response;
        }

        [Route("dropdown")]
        [HttpGet]
        [Authorize]
        public async Task<ResponseModel> Dropdown()
        {
            var response = await _providerService.DropdownSelection();
            return response;
        }
    }
}