using Microsoft.AspNetCore.Mvc;
using MVC.Services;

namespace MVC.Controllers
{
    public class JobDescriptionController : Controller
    {
        private readonly JobDescriptionService _jobDescriptionService;

        public JobDescriptionController(JobDescriptionService jobDescriptionService)
        {
            _jobDescriptionService = jobDescriptionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllPaging(int page, int pagesize, string keyword, int categoryid, int type)
        {
            var result = _jobDescriptionService.GetJobPaging(page, pagesize, keyword, categoryid, type);
            return Json(result);
        }
    }
}