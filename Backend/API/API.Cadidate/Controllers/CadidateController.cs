using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Cadidates.Interfaces;
using Services.Cadidates.ViewModel;
using System.Threading.Tasks;

namespace API.Cadidate.Controllers
{
    [Route("/api/cadidate/cadidate")]
    [ApiController]
    public class CadidateController : ControllerBase
    {
        private readonly ICadidateService _cadidateService;

        public CadidateController(ICadidateService cadidateService)
        {
            _cadidateService = cadidateService;
        }

        [HttpPost]
        [Route("insert")]
        [Authorize]
        public async Task<ResponseModel> Insert([FromForm] CadidateViewModel model)
        {
            var response = await _cadidateService.Insert(model);
            return response;
        }

        [HttpGet]
        [Route("item")]
        [Authorize]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _cadidateService.Item(id);
            return response;
        }

        [HttpDelete]
        [Route("delete")]
        [Authorize]
        public async Task<ResponseModel> Delete([FromBody] CadidateViewModel model)
        {
            var response = await _cadidateService.Delete(model);
            return response;
        }

        [HttpPut]
        [Route("update")]
        [Authorize]
        public async Task<ResponseModel> Update([FromBody] CadidateViewModel model)
        {
            var response = await _cadidateService.Update(model);
            return response;
        }
    }
}
