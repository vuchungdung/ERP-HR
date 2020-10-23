using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Services.System.Interfaces;
using Services.System.ViewModel;
using System.Threading.Tasks;

namespace API.System.Controllers
{
    [Route("/api/system/authen")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [Route("login")]
        [HttpPost]
        public Task<ResponseModel> Login([FromBody] LoginViewModel model)
        {
            var response = _authenticationService.AuthencitateUser(model);
            return response;
        }
    }
}