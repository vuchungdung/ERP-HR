using Core.CommonModel;
using Core.CommonModel.Enum;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.Cadidate;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.Cadidates.Interfaces;
using Services.Cadidates.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Services.Cadidates.Implement
{
    public class ApplyHistoryService : IApplyHistoryService
    {
        private readonly IERPUnitOfWork _context;
        private IHttpContextAccessor _httpContext;

        public ApplyHistoryService(IERPUnitOfWork context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                CadidateApplyHistory md = _context.CadidateApplyHistoryRepository.FirstOrDefault(x => x.Id == id && !x.Deleted);

                if(md == null)
                {
                    throw new Exception();
                }

                md.Deleted = true;
                md.UpdateBy = 1;
                md.UpdateDate = DateTime.Now;

                _context.CadidateApplyHistoryRepository.Update(md);

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
                var query = from a in _context.CadidateApplyHistoryRepository.Query()
                            where !a.Deleted && a.CadidateId == userId
                            orderby a.TimeStart
                            select new ApplyHistoryViewModel()
                            {
                                Id = a.Id,
                                CadidateId = a.CadidateId,
                                TimeStart = a.TimeStart,
                                TimeEnd = a.TimeEnd,
                                Company = a.Company,
                                Description = a.Description
                            };
                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(x => x.Company.ToLower().Contains(filter.Text.ToLower())
                                        || x.Description.ToLower().Contains(filter.Text.ToLower()));
                }
                BaseListModel<ApplyHistoryViewModel> listItems = new BaseListModel<ApplyHistoryViewModel>();

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

        public async Task<ResponseModel> Insert(ApplyHistoryViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                CadidateApplyHistory md = new CadidateApplyHistory();

                md.CadidateId = model.CadidateId;
                md.Company = model.Company;
                md.Description = model.Description;
                md.TimeStart = model.TimeStart;
                md.TimeEnd = md.TimeEnd;
                md.Deleted = false;
                md.CreateDate = DateTime.Now;
                md.CreateBy = 1;

                await _context.CadidateApplyHistoryRepository.AddAsync(md);

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
                CadidateApplyHistory md = await _context.CadidateApplyHistoryRepository.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);

                ApplyHistoryViewModel model = new ApplyHistoryViewModel()
                {
                    Id = md.Id,
                    CadidateId = md.CadidateId,
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

        public async Task<ResponseModel> Update(ApplyHistoryViewModel model)
        { 
            ResponseModel response = new ResponseModel();
            try
            {
                CadidateApplyHistory md = _context.CadidateApplyHistoryRepository.FirstOrDefault(x => x.Id == model.Id);

                md.Company = model.Company;
                md.TimeStart = model.TimeStart;
                md.TimeEnd = model.TimeEnd;
                md.Description = model.Description;
                md.UpdateBy = 1;
                md.UpdateDate = DateTime.Now;

                _context.CadidateApplyHistoryRepository.Update(md);

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
