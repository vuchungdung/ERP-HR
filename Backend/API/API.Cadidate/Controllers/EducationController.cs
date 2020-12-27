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
    [Route("/api/candidate/education")]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpPost]
        [Route("get-list")]
        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            var response = await _educationService.GetList(filter);
            return response;
        }
    }
}
