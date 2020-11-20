using Core.CommonModel;
using Core.CommonModel.Enum;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.Recruitment;
using Database.Sql.ERP.Entities.System;
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
    public class JobDescriptionService : IJobDescriptionService
    {
        private readonly IERPUnitOfWork _context;
        private IHttpContextAccessor _httpContext;

        public JobDescriptionService(IERPUnitOfWork context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }
        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                JobDescription md = _context.JobDescriptionRepository.FirstOrDefault(x => x.JobId == id && !x.Deleted);

                md.Deleted = true;
                md.UpdateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                md.UpdateDate = DateTime.Now;

                _context.JobDescriptionRepository.Update(md);

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
                var query = from j in _context.JobDescriptionRepository.Query()
                            join c in _context.JobCategoryRepository.Query()
                            on j.CategoryId equals c.CategoryId
                            where !j.Deleted
                            orderby j.CreateDate
                            select new JobDescriptionViewModel()
                            {
                                JobId = j.JobId,
                                Title = j.Title,
                                Quatity = j.Quatity,
                                TimeStart = j.TimeStart,
                                TimeEnd = j.TimeEnd,
                                Skill = j.SkillId,
                                CategoryName = c.Name,
                                OfferFrom = j.OfferFrom,
                                OfferTo = j.OfferTo
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(x => x.CategoryName.ToLower().Contains(filter.Text.ToLower())
                                        || x.Skill.ToLower().Contains(filter.Text.ToLower())
                                        || x.Title.ToLower().Contains(filter.Text.ToLower()));
                }

                BaseListModel<JobDescriptionViewModel> listItems = new BaseListModel<JobDescriptionViewModel>();

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

        public async Task<ResponseModel> Insert(JobDescriptionViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                JobDescription md = new JobDescription();

                md.Title = model.Title;
                md.Description = model.Description;
                md.Endow = model.Endow;
                md.SkillId = model.Skill;
                md.CategoryId = model.CategoryId;
                md.OfferFrom = model.OfferFrom;
                md.OfferTo = model.OfferTo;
                md.CreateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                md.CreateDate = DateTime.Now;
                md.Status = model.Status;
                md.RequestJob = model.RequestJob;
                md.Deleted = false;
                md.TimeStart = model.TimeStart;
                md.TimeEnd = model.TimeEnd;
                md.Quatity = model.Quatity;
                md.Benefit = model.Benefit;

                await _context.JobDescriptionRepository.AddAsync(md);

                await _context.SaveChangesAsync();

                response.Status = ResponseStatus.Success;
            }
            catch (Exception ex)
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
                JobDescription md = await _context.JobDescriptionRepository.FirstOrDefaultAsync(x => x.JobId == id && !x.Deleted);

                JobDescriptionViewModel model = new JobDescriptionViewModel();

                model.JobId = md.JobId;
                model.Title = md.Title;
                model.Description = md.Description;
                model.Endow = md.Endow;
                model.CategoryId = md.CategoryId;
                model.OfferFrom = md.OfferFrom;
                model.OfferTo = md.OfferTo;
                model.Status = md.Status;
                model.TimeEnd = md.TimeEnd;
                model.TimeStart = md.TimeStart;
                model.Benefit = md.Benefit;
                model.Quatity = md.Quatity;
                model.RequestJob = md.RequestJob;

                response.Result = model;
                response.Status = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(JobDescriptionViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                JobDescription md = _context.JobDescriptionRepository.FirstOrDefault(x => x.JobId == model.JobId && !x.Deleted);

                md.Title = model.Title;
                md.Description = model.Description;
                md.Endow = model.Endow;
                md.SkillId = model.Skill;
                md.CategoryId = model.CategoryId;
                md.OfferFrom = model.OfferFrom;
                md.OfferTo = model.OfferTo;
                md.Status = model.Status;
                md.Benefit = model.Benefit;
                md.TimeEnd = model.TimeEnd;
                md.TimeStart = model.TimeStart;
                md.RequestJob = model.RequestJob;
                md.Quatity = model.Quatity;
                md.Status = model.Status;
                md.UpdateDate = DateTime.Now;
                md.UpdateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                _context.JobDescriptionRepository.Update(md);

                response.Result = md;
                response.Status = ResponseStatus.Success;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}
