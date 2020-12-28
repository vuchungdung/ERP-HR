using Core.CommonModel;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.Interview;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.Interview.Interfaces;
using Services.Interview.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Interview.Implement
{
    public class InterviewProcessService : IInterviewProcessService 
    {
        private readonly IERPUnitOfWork _context;
        private IHttpContextAccessor _httpContext;

        public InterviewProcessService(IERPUnitOfWork context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }
        public Task<ResponseModel> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from a in _context.ApplyRepository.Query()
                            join i in _context.InterviewProcessRepository.Query()
                            on a.Id equals i.ApplyId
                            join p in _context.ProcessRepository.Query()
                            on i.ProcessId equals p.ProcessId
                            where a.CandidateId == Convert.ToInt32(filter.CandidateId)
                            select new InterviewProcessViewModel()
                            {
                                Id = i.Id,
                                ApplyId = a.Id,
                                Processname = p.Name,
                                Result = i.Result,
                                ProcessId = i.ProcessId
                            };

                var listItems = await query.ToListAsync();

                response.Result = listItems;
                response.Status = Core.CommonModel.Enum.ResponseStatus.Success;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Insert(InterviewProcessViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                InterviewProcess md = new InterviewProcess();
                md.ApplyId = model.ApplyId;
                md.CreateBy = 1;
                md.CreateDate = DateTime.Now;
                md.Deleted = false;
                md.ProcessId = model.ProcessId + 1;
                if(md.ProcessId > 3)
                {
                    response.Status = Core.CommonModel.Enum.ResponseStatus.Error;
                }
                else
                {
                    md.isShow = true;

                    await _context.InterviewProcessRepository.AddAsync(md);

                    await _context.SaveChangesAsync();
                    response.Status = Core.CommonModel.Enum.ResponseStatus.Success;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public Task<ResponseModel> Item(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> Update(InterviewProcessViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                InterviewProcess md = _context.InterviewProcessRepository.FirstOrDefault(x => x.Id == model.Id);
                md.Result = model.Result;
                _context.InterviewProcessRepository.Update(md);

                await _context.SaveChangesAsync();
                response.Status = Core.CommonModel.Enum.ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public bool UpdateStatus(InterviewProcessViewModel model)
        {
            try
            {
                InterviewProcess md = _context.InterviewProcessRepository.FirstOrDefault(x => x.ApplyId == model.ApplyId && x.isShow == true);
                if(model.ProcessId + 1 > 3)
                {
                    return true;
                }
                else
                {
                    md.isShow = false;
                    _context.InterviewProcessRepository.Update(md);

                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
