using Microsoft.AspNetCore.Mvc;
using Services.Cadidates.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
