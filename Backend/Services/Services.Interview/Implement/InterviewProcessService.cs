using Core.CommonModel;
using Services.Interview.Interfaces;
using Services.Interview.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interview.Implement
{
    public class InterviewProcessService : IInterviewProcessService 
    {
        public Task<ResponseModel> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetList(FilterModel filter)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Insert(InterviewProcessViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Item(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(InterviewProcessViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
