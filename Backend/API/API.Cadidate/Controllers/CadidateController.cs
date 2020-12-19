using Core.CommonModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Candidates.Interfaces;
using Services.Candidates.ViewModel;
using System.Threading.Tasks;

namespace API.Candidate.Controllers
{
    [Route("/api/candidate/candidate")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _cadidateService;

        public CandidateController(ICandidateService cadidateService)
        {
            _cadidateService = cadidateService;
        }

        [HttpPost]
        [Route("insert")]
        [Authorize]
        public async Task<ResponseModel> Insert([FromForm] CandidateViewModel model)
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
        public async Task<ResponseModel> Delete([FromQuery] int id)
        {
            var response = await _cadidateService.Delete(id);
            return response;
        }

        [HttpPut]
        [Route("update")]
        [Authorize]
        public async Task<ResponseModel> Update([FromBody] CandidateViewModel model)
        {
            var response = await _cadidateService.Update(model);
            return response;
        }

        [HttpPost]
        [Route("get-list")]
        [Authorize]
        public async Task<ResponseModel> GetList([FromBody] FilterModel model)
        {
            var response = await _cadidateService.GetList(model);
            return response;
        }
    }
}