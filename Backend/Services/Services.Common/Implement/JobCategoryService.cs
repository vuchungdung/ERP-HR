using Core.CommonModel;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.Common;
using Services.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Services.Common.ViewModel;
using System.Security.Claims;
using Core.CommonModel.Enum;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;

namespace Services.Common.Implement
{
    public class JobCategoryService : IJobCategoryService
    {
        private readonly IERPUnitOfWork _context;
        private IHttpContextAccessor _httpContext;

        public JobCategoryService(IERPUnitOfWork context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                JobCategory md = _context.JobCategoryRepository.FirstOrDefault(x => x.CategoryId == id && !x.Deleted);

                md.Deleted = true;
                md.UpdateDate = DateTime.Now;
                md.UpdateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier));

                _context.JobCategoryRepository.Update(md);

                await _context.SaveChangesAsync();

                response.Status = ResponseStatus.Success;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> DropdowmSelection()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from p in _context.JobCategoryRepository.Query()
                            where !p.Deleted
                            orderby p.Name
                            select new JobCategoryViewModel()
                            {
                                CategoryId = p.CategoryId,
                                Name = p.Name,
                                Description = p.Description
                            };

                List<JobCategoryViewModel> items = await query.ToListAsync();

                response.Result = items;
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
                var query = from m in _context.JobCategoryRepository.Query()
                            where !m.Deleted
                            orderby m.Name
                            select new JobCategoryViewModel()
                            {
                                CategoryId = m.CategoryId,
                                Name = m.Name,
                                Description = m.Description
                            };
                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(x => x.Name.ToLower().Contains(filter.Text.ToLower())
                                    || x.Description.ToLower().Contains(filter.Text.ToLower()));
                }
                BaseListModel<JobCategoryViewModel> listItems = new BaseListModel<JobCategoryViewModel>();

                listItems.Items = await query.Skip((filter.Paging.PageIndex - 1) * filter.Paging.PageSize)
                                    .Take(filter.Paging.PageSize)
                                    .OrderByDescending(x => x.Name)
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

        public async Task<ResponseModel> Insert(JobCategoryViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                JobCategory md = new JobCategory();

                md.Name = model.Name;
                md.Description = model.Description;
                md.CreateDate = DateTime.Now;
                md.CreateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                await _context.JobCategoryRepository.AddAsync(md);
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
                JobCategory md = await _context.JobCategoryRepository.FirstOrDefaultAsync(x => x.CategoryId == id);

                JobCategoryViewModel model = new JobCategoryViewModel();

                model.CategoryId = md.CategoryId;
                model.Name = md.Name;
                model.Description = md.Description;

                response.Result = model;
                response.Status = ResponseStatus.Success;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(JobCategoryViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                JobCategory md = _context.JobCategoryRepository.FirstOrDefault(x => x.CategoryId == model.CategoryId);

                md.Name = model.Name;
                md.Description = model.Description;
                md.UpdateDate = DateTime.Now;
                md.UpdateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                _context.JobCategoryRepository.Update(md);

                await _context.SaveChangesAsync();

                response.Status = ResponseStatus.Success;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}
