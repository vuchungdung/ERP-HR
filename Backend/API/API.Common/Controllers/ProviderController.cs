using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Common.Interfaces;
using Services.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Common.Controllers
{
    [ApiController]
    [Route("/api/common/provider")]
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
    }
}
