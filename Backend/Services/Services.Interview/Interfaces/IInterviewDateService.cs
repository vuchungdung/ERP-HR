using Core.CommonModel;
using Core.Services.InterfaceService;
using Services.Interview.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interview.Interfaces
{
    public interface IInterviewDateService : IBaseInterfaceService<InterviewDateViewModel>
    {
        List<ListDate> GetDate();
    }
}
