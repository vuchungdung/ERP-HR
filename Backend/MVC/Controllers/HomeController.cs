using Core.CommonModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
using Services.Recruitment.Interface;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IJobDescriptionService _jobDescriptionService;

        public HomeController(ILogger<HomeController> logger, IJobDescriptionService jobDescriptionService)
        {
            _logger = logger;
            _jobDescriptionService = jobDescriptionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ResponseModel> GetListJob(FilterModel model)
        {
            var response = await _jobDescriptionService.GetList(model);
            return response;
        }
    }
}