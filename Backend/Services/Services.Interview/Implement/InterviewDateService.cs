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

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from i in _context.InterviewDateRepository.Query()
                            where !i.Deleted
                            orderby i.TimeDate
                            select new InterviewDateViewModel()
                            {
                                DateId = i.DateId,
                                TimeDate = i.TimeDate,
                                TimeStart = i.TimeStart,
                                Address = i.Address,
                                RecruitType = i.RecruitType,
                                Time = i.Time,
                                JodId = i.JodId,
                                Note = i.Note,
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(x => x.TimeDate == Convert.ToDateTime(filter.Text));
                }

                BaseListModel<InterviewDateViewModel> listItems = new BaseListModel<InterviewDateViewModel>();

                listItems.Items = await query.Skip((filter.Paging.PageIndex - 1) * filter.Paging.PageSize)
                    .Take(filter.Paging.PageSize)
                    .ToListAsync()
                    .ConfigureAwait(true);

                listItems.TotalItems = await query.CountAsync();

                response.Result = listItems;
                response.Status = ResponseStatus.Success;

            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
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
                md.JodId = model.JodId;
                md.Time = md.Time;
                md.RecruitType = model.RecruitType;
                md.TimeStart = model.TimeStart;
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

                InterviewDate model = new InterviewDate();

                model.DateId = md.DateId;
                model.Address = md.Address;
                model.CreateDate = DateTime.Now;
                model.JodId = md.JodId;
                model.Time = md.Time;
                model.RecruitType = md.RecruitType;
                model.TimeStart = md.TimeStart;
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
