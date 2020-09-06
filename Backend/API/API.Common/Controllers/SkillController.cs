﻿using Core.CommonModel;
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
        [Route("item")]
        public async Task<ResponseModel> Item([FromQuery] int id)
        {
            var response = await _skillService.Item(id);
            return response;
        }

        [HttpPost]
        [Route("insert")]
        public async Task<ResponseModel> Insert([FromBody] SkillViewModel model)
        {
            var response = await _skillService.Insert(model);
            return response;
        }
    }
}
