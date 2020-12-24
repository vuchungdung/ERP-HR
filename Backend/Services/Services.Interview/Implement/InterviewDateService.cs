using Core.CommonModel;
using Core.CommonModel.Enum;
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
    public class InterviewDateService : IInterviewDateService
    {
        private readonly IERPUnitOfWork _context;
        private IHttpContextAccessor _httpContext;

        public InterviewDateService(IERPUnitOfWork context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }
        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                InterviewDate md = _context.InterviewDateRepository.FirstOrDefault(x => x.DateId == id && !x.Deleted);

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

        public List<ListDate> GetDate()
        {
            try
            {
                var query = from i in _context.InterviewDateRepository.Query()
                            join j in _context.EmployeeRepository.Query()
                            on i.EmployeeId equals j.Id
                            join c in _context.CandidateRepository.Query()
                            on i.CandidateId equals c.CandidateId
                            where !i.Deleted && !j.Deleted && !c.Deleted
                            orderby i.TimeDate
                            select new ListDate()
                            {
                                DateId = i.DateId,
                                Title = j.Name+" với "+c.Name,
                                Date = i.TimeDate
                            };



                var listItems = query.ToList();

                return listItems;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task<ResponseModel> GetList(FilterModel filter)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> Insert(InterviewDateViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                InterviewDate md = new InterviewDate();

                md.Address = model.Address;
                md.CreateDate = DateTime.Now;
                md.CreateBy = 1;
                md.Deleted = false;
                md.CandidateId = model.CandidateId;
                md.EmployeeId = model.EmployeeId;
                md.JodId = model.JodId;
                md.Time = md.Time;
                md.RecruitType = model.RecruitType;
                md.TimeDate = model.TimeDate;
                md.Note = model.Note;

                await _context.InterviewDateRepository.AddAsync(md);

                await _context.SaveChangesAsync();

                response.Status = ResponseStatus.Success;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Item(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                InterviewDate md = await _context.InterviewDateRepository.FirstOrDefaultAsync(x => x.DateId == id && !x.Deleted);

                InterviewDateViewModel model = new InterviewDateViewModel();

                model.DateId = md.DateId;
                model.Address = md.Address;
                model.CandidateId = md.CandidateId;
                model.EmployeeId = md.EmployeeId;
                model.JodId = md.JodId;
                model.Time = md.Time;
                model.RecruitType = md.RecruitType;
                model.TimeDate = md.TimeDate;
                model.Note = md.Note;

                response.Result = model;
                response.Status = ResponseStatus.Success;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(InterviewDateViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}
