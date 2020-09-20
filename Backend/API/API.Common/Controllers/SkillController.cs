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
    [Route("/api/common/skill")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private ISkillService _skillService;
        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        [Authorize]
        [Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _skillService.Item(id);
            return response;
        }

        [HttpPost]
        [Authorize]
        [Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] SkillViewModel model)
        {
            var response = await _skillService.Insert(model);
            return response;
        }

        [HttpPost]
        [Authorize]
        [Route("get-list")]
        public async Task<ResponseModel> GetList([FromBody] FilterModel model)
        {
            var response = await _skillService.GetList(model);
            return response;
        }

        [HttpPut]
        [Authorize]
        [Route("update")]
        public async Task<ResponseModel> Update([FromBody] SkillViewModel model)
        {
            var response = await _skillService.Update(model);
            return response;
        }

        [HttpDelete]
        [Authorize]
        [Route("delete")]
        public async Task<ResponseModel> Delete([FromBody] SkillViewModel model)
        {
            var response = await _skillService.Delete(model);
            return response;
        }
    }
}
