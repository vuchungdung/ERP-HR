using Core.CommonModel;
using Core.EmailSender;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interview.Interfaces;
using Services.Interview.ViewModel;
using System.Threading.Tasks;
namespace API.Interview.Controller
{
    [Route("/api/interview/interviewdate")]
    [ApiController]
    public class InterviewDateController : ControllerBase
    {
        private readonly IInterviewDateService _interviewDateService;
        private readonly IEmailSender _emailSender;

        public InterviewDateController(IInterviewDateService interviewDateService, IEmailSender emailSender)
        {
            _interviewDateService = interviewDateService;
            _emailSender = emailSender;
        }

        [HttpPost]
        [Route("insert")]
        [Authorize]
        public async Task<ResponseModel> Insert([FromForm] InterviewDateViewModel model)
        {
            var message = new Message(
                new string[] { model.Email },
                "Thư mời phỏng vấn",
                "Chúc mừng bạn đã nhận được thư mời phỏng vấn. Ngày "+model.TimeDate.Day+" tại "+model.Address+".Mong bạn có mặt đúng hẹn! Chúng tôi xin trân thành cảm ơn.", null);
            _emailSender.SendEmail(message);
            var response = await _interviewDateService.Insert(model);
            return response;
        }

        [HttpPost]
        [Route("get-list")]
        [Authorize]
        public async Task<ResponseModel> GetList([FromBody] FilterModel model)
        {
            var response = await _interviewDateService.GetList(model);
            return response;
        }
    }
}
