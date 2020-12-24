using Core.CommonModel;
using Core.EmailSender;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interview.Interfaces;
using Services.Interview.ViewModel;
using System.Collections.Generic;
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
            if(model.SendMail == true)
            {
                var message = new Message(
                new string[] { model.Email },
                "Thư mời phỏng vấn",
                "Chúc mừng bạn đã nhận được thư mời phỏng vấn. Ngày " + model.TimeDate.Date + " tại " + model.Address + ".Mong bạn có mặt đúng hẹn! Chúng tôi xin trân thành cảm ơn.", null);
                _emailSender.SendEmail(message);
            }
            var response = await _interviewDateService.Insert(model);
            return response;
        }

        [HttpGet]
        [Route("get-date")]
        public List<ListDate> GetDate()
        {
            var response = _interviewDateService.GetDate();
            return response;
        }
    }
}
