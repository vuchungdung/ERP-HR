using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.System.Interfaces;
using Services.System.ViewModel;
using System.Threading.Tasks;

namespace API.System.Controllers
{
    [Route("/api/system/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [Authorize]
        [HttpPost]
        [Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] RoleViewModel model)
        {
            var response = await _roleService.Insert(model);
            return response;
        }

        [Authorize]
        [HttpDelete]
        [Route("delete")]
        public async Task<ResponseModel> Delete([FromQuery] int id)
        {
            var response = await _roleService.Delete(id);
            return response;
        }

        [Authorize]
        [HttpPut]
        [Route("update")]
        public async Task<ResponseModel> Update([FromBody] RoleViewModel model)
        {
            var response = await _roleService.Update(model);
            return response;
        }

        [Authorize]
        [HttpGet]
        [Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _roleService.Item(id);
            return response;
        }
    }
}