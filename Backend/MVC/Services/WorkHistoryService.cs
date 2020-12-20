using MVC.Helper;
using MVC.Models;
using MVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Services
{
    public class WorkHistoryService : IWorkHistoryService
    {
        private readonly IDatabaseHelper _helper;

        public WorkHistoryService(IDatabaseHelper helper)
        {
            _helper = helper;
        }

        public bool Create(WorkHistoryViewModel model)
        {
            try
            {
                var response = _helper.ExecuteSProcedure("SP_CREATE_WORK", "@createby", model.CreateBy,
                                                           "@candidateid", model.CandidateId,
                                                           "@company", model.Company,
                                                           "@description", model.Description,
                                                           "@position", model.Position,
                                                           "@timeend", model.TimeEnd,
                                                           "@timestart", model.TimeStart,
                                                           "@createdate",DateTime.Now);
                if (response != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<WorkHistoryViewModel> GetByCId(int id)
        {
            try
            {
                var response = _helper.ExecuteSProcedure("SP_GET_WORK", "@candidateid", id);
                return response.ConvertTo<WorkHistoryViewModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(WorkHistoryViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
