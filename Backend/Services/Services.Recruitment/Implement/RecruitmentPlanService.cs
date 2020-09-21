using Core.CommonModel;
using Core.CommonModel.Enum;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.Recruitment;
using Microsoft.AspNetCore.Http;
using Services.Recruitment.Interface;
using Services.Recruitment.ViewModel;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Services.Recruitment.Implement
{
    public class RecruitmentPlanService : IRecruitmentPlanService
    {
        private readonly IERPUnitOfWork _context;
        private IHttpContextAccessor _httpContext;

        public RecruitmentPlanService(IERPUnitOfWork context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public async Task<ResponseModel> Delete(RecruitmentPlanViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                RecruitmentPlan md = _context.RecruitmentPlanRepository.FirstOrDefault(x => x.PlanId == model.PlanId && !x.Deleted);

                md.Deleted = true;
                md.UpdateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                md.UpdateDate = DateTime.Now;

                _context.RecruitmentPlanRepository.Update(md);

                await _context.SaveChangesAsync();

                response.Status = ResponseStatus.Success;
            }
            catch (Exception ex)
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
                var query = from r in _context.RecruitmentPlanRepository.Query()
                            join j in _context.JobDescriptionRepository.Query()
                            on r.JobId equals j.JobId
                            join jc in _context.JobCategoryRepository.Query()
                            on j.CategoryId equals jc.CategoryId
                            where !r.Deleted && !j.Deleted && !jc.Deleted
                            orderby r.CreateDate
                            select new RecruitmentPlanViewModel()
                            {
                                PlanId = r.PlanId,
                                JobId = r.JobId,
                                Quatity = r.Quatity,
                                Status = r.Status,
                                Note = r.Note,
                                JobTitle = j.Title,
                                TimeEnd = r.TimeEnd,
                                TimeStart = r.TimeStart,
                                CreateDate = r.CreateDate
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(x => x.JobTitle.ToLower().Contains(filter.Text.ToLower()));
                }

                BaseListModel<RecruitmentPlanViewModel> listItems = new BaseListModel<RecruitmentPlanViewModel>();

                listItems.Items = await query.Skip((filter.Paging.PageIndex - 1) * filter.Paging.PageSize)
                                                .Take(filter.Paging.PageSize)
                                                .OrderByDescending(x => x.CreateDate)
                                                .ToListAsync()
                                                .ConfigureAwait(true);

                listItems.TotalItems = await query.CountAsync();

                response.Result = listItems;
                response.Status = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public Task<ResponseModel> Insert(RecruitmentPlanViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Item(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(RecruitmentPlanViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
