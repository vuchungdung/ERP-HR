using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Common.Interfaces;
using Services.Common.ViewModel;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Common.Controllers
{
    [Route("/api/common/tag")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [Route("insert")]
        [HttpPost]
        [Authorize]
        public async Task<ResponseModel> Insert([FromBody]TagViewModel model)
        {
            var response = await _tagService.Insert(model);
            return response;
        }

        [Route("item")]
        [HttpGet]
        [Authorize]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _tagService.Item(id);
            return response;
        }

        [Route("get-list")]
        [HttpPost]
        [Authorize]
        public async Task<ResponseModel> GetList ([FromBody] FilterModel model)
        {
            var response = await _tagService.GetList(model);
            return response;
        }
        [Route("update")]
        [HttpPut]
        [Authorize]
        public async Task<ResponseModel> Update([FromBody] TagViewModel model)
        {
            var response = await _tagService.Update(model);
            return response;
        }
        [Route("delete")]
        [HttpDelete]
        [Authorize]
        public async Task<ResponseModel> Delete([FromBody] TagViewModel model)
        {
            var response = await _tagService.Delete(model);
            return response;
        }
    }
}
