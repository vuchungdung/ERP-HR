using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Services.Common.Implement;
using Services.Common.Interfaces;
using Services.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
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
        public async Task<ResponseModel> Insert([FromBody]TagViewModel model)
        {
            var response = await _tagService.Insert(model);
            return response;
        }
    }
}
