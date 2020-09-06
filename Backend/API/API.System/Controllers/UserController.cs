using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Services.System.Interfaces;
using Services.System.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.System.Controllers
{
    [Route("/api/system/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] UserViewModel model)
        {
            var response = await _userService.Insert(model);
            return response;
        }

        [HttpGet]
        [Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _userService.Item(id);
            return response;
        }

    }
}
