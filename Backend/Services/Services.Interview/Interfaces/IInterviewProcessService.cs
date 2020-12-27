using Core.Services.InterfaceService;
using Services.Interview.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interview.Interfaces
{
    public interface IInterviewProcessService : IBaseInterfaceService<InterviewProcessViewModel>
    {
        bool UpdateStatus(InterviewProcessViewModel model);
    }
}
