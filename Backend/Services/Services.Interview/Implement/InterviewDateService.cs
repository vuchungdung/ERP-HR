using Core.CommonModel;
using Core.CommonModel.Enum;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.Interview;
using Microsoft.AspNetCore.Http;
using Services.Interview.Interfaces;
using Services.Interview.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interview.Implement
{
    public class InterviewDateService : IInterviewDateService
    {
        private readonly IERPUnitOfWork _context;
        private IHttpContextAccessor _httpContext;

        public InterviewDateService(IERPUnitOfWork context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }
        public async Task<ResponseModel> Delete(InterviewDateViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                InterviewDate md = _context.InterviewDateRepository.FirstOrDefault(x => x.DateId == model.DateId && !x.Deleted);

                if(md == null)
                {
                    throw new Exception();
                }

                md.Deleted = true;
                md.UpdateBy = 1;
                md.UpdateDate = DateTime.Now;

                _context.InterviewDateRepository.Update(md);

                await _context.SaveChangesAsync();

                response.Status = ResponseStatus.Success;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public Task<ResponseModel> GetList(FilterModel filter)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Insert(InterviewDateViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Item(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(InterviewDateViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
