using Core.CommonModel;
using Core.CommonModel.Enum;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.Common;
using Microsoft.AspNetCore.Http;
using Services.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Services.Common.Interfaces;

namespace Services.Common.Implement
{
    public class ProcessService : IProcessService
    {
        private readonly IERPUnitOfWork _context;
        private IHttpContextAccessor _httpContext;

        public ProcessService(IERPUnitOfWork context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }
        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Process md = _context.ProcessRepository.FirstOrDefault(x => x.ProcessId == id && !x.Deleted);

                md.Deleted = true;
                md.UpdateDate = DateTime.Now;
                md.UpdateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                _context.ProcessRepository.Update(md);

                await _context.SaveChangesAsync();

                response.Status = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public Task<ResponseModel> DropdowmSelection()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.ProcessRepository.Query()
                            where !m.Deleted
                            orderby m.Name
                            select new ProcessViewModel()
                            {
                                ProcessId = m.ProcessId,
                                Name = m.Name,
                                Note = m.Note

                            };
                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(x => x.Name.ToLower().Contains(filter.Text.ToLower()));
                }
                BaseListModel<ProcessViewModel> listItems = new BaseListModel<ProcessViewModel>();
                listItems.Items = await query
                    .Skip((filter.Paging.PageIndex - 1) * filter.Paging.PageSize)
                    .Take(filter.Paging.PageSize).OrderByDescending(x => x.Name)
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

        public async Task<ResponseModel> Insert(ProcessViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Process md = new Process();

                md.Name = model.Name;
                md.CreateDate = DateTime.Now;
                md.CreateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                await _context.ProcessRepository.AddAsync(md);

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
                Process md = await _context.ProcessRepository.FirstOrDefaultAsync(x => x.ProcessId == id);

                ProcessViewModel model = new ProcessViewModel()
                {
                    ProcessId = md.ProcessId,
                    Name = md.Name,
                    Note = md.Note
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

        public async Task<ResponseModel> Update(ProcessViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Process md = _context.ProcessRepository.FirstOrDefault(x => x.ProcessId == model.ProcessId);

                md.Name = model.Name;
                md.Note = md.Note;
                md.UpdateDate = DateTime.Now;
                md.UpdateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                _context.ProcessRepository.Update(md);

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
