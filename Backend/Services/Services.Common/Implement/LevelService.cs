using Core.CommonModel;
using Core.CommonModel.Enum;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.Common;
using Microsoft.AspNetCore.Http;
using Services.Common.Interfaces;
using Services.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Services.Common.Implement
{
    public class LevelService : ILevelService
    {
        private readonly IERPUnitOfWork _context;
        private IHttpContextAccessor _httpContext;

        public LevelService(IERPUnitOfWork context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }
        public async Task<ResponseModel> Delete(LevelViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Level md = _context.LevelRepository.FirstOrDefault(x => x.LevelId == model.LevelId);

                md.Deleted = true;
                md.UpdateDate = DateTime.Now;
                md.UpdateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                _context.LevelRepository.Update(md);

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
                var query = from m in _context.LevelRepository.Query()
                            where !m.Deleted
                            orderby m.Name
                            select new LevelViewModel()
                            {
                                LevelId = m.LevelId,
                                Name = m.Name,
                                Description = m.Description
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(x => x.Name.ToLower().Contains(filter.Text.ToLower())
                    || x.Description.ToLower().Contains(filter.Text.ToLower()));
                }

                BaseListModel<LevelViewModel> listItems = new BaseListModel<LevelViewModel>();

                listItems.Items = await query.Skip((filter.Paging.PageIndex - 1) * filter.Paging.PageSize)
                                        .Take(filter.Paging.PageSize).OrderByDescending(x => x.Name)
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

        public async Task<ResponseModel> Insert(LevelViewModel model)
        { 
            ResponseModel response = new ResponseModel();
            try
            {
                Level md = new Level();

                md.Name = model.Name;
                md.Description = model.Description;
                md.CreateDate = DateTime.Now;
                md.CreateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                await _context.LevelRepository.AddAsync(md);

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
                Level md = await _context.LevelRepository.FirstOrDefaultAsync(x => x.LevelId == id);

                LevelViewModel model = new LevelViewModel()
                {
                    LevelId = md.LevelId,
                    Name = md.Name,
                    Description = md.Description
                };
                response.Result = model;

                response.Status = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(LevelViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Level md = _context.LevelRepository.FirstOrDefault(x => x.LevelId == model.LevelId);

                md.Name = model.Name;
                md.Description = model.Description;
                md.UpdateDate = DateTime.Now;
                md.UpdateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                _context.LevelRepository.Update(md);

                await _context.SaveChangesAsync();

                response.Status = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }
    }
}
