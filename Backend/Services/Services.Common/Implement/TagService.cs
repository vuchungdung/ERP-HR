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
using System.Threading.Tasks;

namespace Services.Common.Implement
{
    public class TagService : ITagService
    {
        private readonly IERPUnitOfWork _context;
        private IHttpContextAccessor _httpContext;

        public TagService(IERPUnitOfWork context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }
        public async Task<ResponseModel> Delete(TagViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Tag md = _context.TagRepository.FirstOrDefault(x => x.Id == model.Id && !x.Deleted);

                md.Deleted = true;
                md.UpdateBy = 1;
                md.UpdateDate = DateTime.Now;

                _context.TagRepository.Update(md);

                await _context.SaveChangesAsync();

                response.Status = ResponseStatus.Success;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response; 
        }

        public Task<ResponseModel> DropdownSelection()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from t in _context.TagRepository.Query()
                            where !t.Deleted
                            orderby t.CreateDate
                            select new TagViewModel()
                            {
                                Name = t.Name,
                                Color = t.Color,
                                Content = t.Content
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(x => x.Name.ToLower().Contains(filter.Text.ToLower())
                                        || x.Content.ToLower().Contains(filter.Text.ToLower()));
                }

                BaseListModel<TagViewModel> listItems = new BaseListModel<TagViewModel>();

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

        public async Task<ResponseModel> Insert(TagViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Tag md = new Tag();

                md.Name = model.Name;
                md.Content = model.Content;
                md.Color = model.Color;
                md.CreateDate = DateTime.Now;
                md.CreateBy = 1;

                await _context.TagRepository.AddAsync(md);

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
                Tag md = await _context.TagRepository.FirstOrDefaultAsync(x => x.Id == id && !x.Deleted);

                if(md == null)
                {
                    throw new Exception();
                }

                TagViewModel model = new TagViewModel();

                model.Id = md.Id;
                model.Name = md.Name;
                model.Content = md.Content;
                model.Color = md.Color;

                response.Result = model;
                response.Status = ResponseStatus.Success;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(TagViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Tag md = _context.TagRepository.FirstOrDefault(x => x.Id == model.Id && !x.Deleted);

                md.Name = model.Name;
                md.Content = model.Content;
                md.Color = model.Color;

                _context.TagRepository.Update(md);

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
