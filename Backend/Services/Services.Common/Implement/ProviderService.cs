using Core.CommonModel;
using Core.CommonModel.Enum;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.Common.Interfaces;
using Services.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Services.Common.Implement
{
    public class ProviderService : IProviderService
    {
        private readonly IERPUnitOfWork _context;
        private IHttpContextAccessor _httpContext;

        public ProviderService(IERPUnitOfWork context,IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public async Task<ResponseModel> Delete(ProviderViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Provider md = _context.ProviderRepository.FirstOrDefault(x => x.ProviderId == model.Id && !x.Deleted);
                md.Deleted = true;
                md.UpdateDate = DateTime.Now;
                md.UpdateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                _context.ProviderRepository.Update(md);

                await _context.SaveChangesAsync();
                response.Status = ResponseStatus.Success;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> DropdownSelection()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from p in _context.ProviderRepository.Query()
                            where !p.Deleted
                            orderby p.Name
                            select new ProviderViewModel()
                            {
                                Id = p.ProviderId,
                                Name = p.Name,
                                Link = p.Link
                            };

                List<ProviderViewModel> items = await query.ToListAsync();

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
                var query = from p in _context.ProviderRepository.Query()
                            where !p.Deleted
                            orderby p.Name
                            select new ProviderViewModel()
                            {
                                Name = p.Name,
                                Link = p.Link,
                                Id = p.ProviderId
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(x => x.Name.ToLower().Contains(filter.Text.ToLower()));
                }

                BaseListModel<ProviderViewModel> listItems = new BaseListModel<ProviderViewModel>();
                listItems.Items = await query.Skip((filter.Paging.PageIndex - 1) * filter.Paging.PageSize)
                    .Take(filter.Paging.PageSize)
                    .ToListAsync()
                    .ConfigureAwait(false);

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

        public async Task<ResponseModel> Insert(ProviderViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Provider md = new Provider();

                md.Name = model.Name;
                md.Link = model.Link;
                md.CreateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                md.CreateDate = DateTime.Now;
                md.Deleted = false;

                await _context.ProviderRepository.AddAsync(md);
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
                Provider md = await _context.ProviderRepository.FirstOrDefaultAsync(x => x.ProviderId == id && !x.Deleted);

                ProviderViewModel model = new ProviderViewModel();

                model.Id = md.ProviderId;
                model.Name = md.Name;
                model.Link = md.Link;

                response.Result = model;
                response.Status = ResponseStatus.Success;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(ProviderViewModel model)
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
