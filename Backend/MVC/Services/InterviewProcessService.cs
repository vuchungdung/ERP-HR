using MVC.Helper;
using MVC.Models;
using MVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Services
{
    public class InterviewProcessService : IInterviewProcessService
    {
        private readonly IDatabaseHelper _helper;
        
        public InterviewProcessService(IDatabaseHelper helper)
        {
            _helper = helper;
        }

        public bool Create(InterviewProcessViewModel model)
        {
            try
            {
                var response = _helper.ExecuteSProcedure("SP_INTERVIEW_P_CREATE",
                    "@applyid", model.ApplyId,
                    "@processid", model.ProcessId,
                    "@createby", model.CreateBy,
                    "@createdate",DateTime.Now);
                if(response != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
