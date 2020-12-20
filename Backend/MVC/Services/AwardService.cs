using MVC.Helper;
using MVC.Models;
using MVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Services
{
    public class AwardService : IAwardService
    {
        private readonly IDatabaseHelper _helper;

        public AwardService(IDatabaseHelper helper)
        {
            _helper = helper;
        }

        public bool Create(AwardsViewModel model)
        {
            try
            {
                var response = _helper.ExecuteSProcedure("SP_CREATE_AWARD", "@createby", model.CreateBy,
                                                           "@candidateid", model.CandidateId,
                                                           "@title", model.Title,
                                                           "@description", model.Description,
                                                           "@institute", model.Institute,
                                                           "@_from", model._From,
                                                           "@_To", model._To,
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

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<AwardsViewModel> GetByCId(int id)
        {
            try
            {
                var response = _helper.ExecuteSProcedure("SP_GET_AWARD", "@candidateid", id);
                return response.ConvertTo<AwardsViewModel>().ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(AwardsViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
