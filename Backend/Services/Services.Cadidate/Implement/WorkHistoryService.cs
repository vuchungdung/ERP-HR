using Core.CommonModel;
using Core.CommonModel.Enum;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.Candidate;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.Candidates.Interfaces;
using Services.Candidates.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Services.Candidates.Implement
{
    public class WorkHistoryService : IWorkHistoryService
    {
        private readonly IERPUnitOfWork _context;
        private IHttpContextAccessor _httpContext;

        public WorkHistoryService(IERPUnitOfWork context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Database.Sql.ERP.Entities.Candidate.WorkHistory md = _context.WorkHistoryRepository.FirstOrDefault(x => x.Id == id && !x.Deleted);

                if(md == null)
                {
                    throw new Exception();
                }

                md.Deleted = true;
                md.UpdateBy = 1;
                md.UpdateDate = DateTime.Now;

                _context.WorkHistoryRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            int userId = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier));
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from a in _context.WorkHistoryRepository.Query()
                            where !a.Deleted && a.CandidateId == userId
                            orderby a.TimeStart
                            select new WorkHistoryViewModel()
                            {
                                Id = a.Id,
                                CandidateId = a.CandidateId,
                                TimeStart = a.TimeStart,
                                TimeEnd = a.TimeEnd,
                                Company = a.Company,
                                Description = a.Description,
                                Position = a.Position
                            };
                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(x => x.Company.ToLower().Contains(filter.Text.ToLower())
                                        || x.Description.ToLower().Contains(filter.Text.ToLower()));
                }
                BaseListModel<WorkHistoryViewModel> listItems = new BaseListModel<WorkHistoryViewModel>();

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

        public async Task<ResponseModel> Insert(WorkHistoryViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Database.Sql.ERP.Entities.Candidate.WorkHistory md = new Database.Sql.ERP.Entities.Candidate.WorkHistory();

                md.CandidateId = model.CandidateId;
                md.Company = model.Company;
                md.Description = model.Description;
                md.TimeStart = model.TimeStart;
                md.TimeEnd = md.TimeEnd;
                md.Deleted = false;
                md.CreateDate = DateTime.Now;
                md.CreateBy = 1;

                await _context.WorkHistoryRepository.AddAsync(md);

                await _context.SaveChangesAsync();
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
                Database.Sql.ERP.Entities.Candidate.WorkHistory md = await _context.WorkHistoryRepository.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);

                WorkHistoryViewModel model = new WorkHistoryViewModel()
                {
                    Id = md.Id,
                    CandidateId = md.CandidateId,
                    Company = md.Company,
                    TimeStart = md.TimeStart,
                    TimeEnd = md.TimeEnd,
                    Description = md.Description
                };

                response.Result = model;
                response.Status = ResponseStatus.Success;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(WorkHistoryViewModel model)
        { 
            ResponseModel response = new ResponseModel();
            try
            {
                Database.Sql.ERP.Entities.Candidate.WorkHistory md = _context.WorkHistoryRepository.FirstOrDefault(x => x.Id == model.Id);

                md.Company = model.Company;
                md.TimeStart = model.TimeStart;
                md.TimeEnd = model.TimeEnd;
                md.Description = model.Description;
                md.UpdateBy = 1;
                md.UpdateDate = DateTime.Now;

                _context.WorkHistoryRepository.Update(md);

                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}
