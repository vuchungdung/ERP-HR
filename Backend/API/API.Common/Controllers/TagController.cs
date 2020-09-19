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
            try
            {
                var id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            var response = await _tagService.Insert(model);
            return response;
        }
    }
}
