using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Services.Cadidates.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace API.Cadidate.Controllers
{
    [ApiController]
    [Route("/api/candidate/award")]
    public class AwardController
    {
        private readonly IAwardService _awardService;

        public AwardController(IAwardService awardService)
        {
            _awardService = awardService;
        }

        [HttpPost]
        [Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _awardService.GetList(filter);
            return response;
        }
    }
}
