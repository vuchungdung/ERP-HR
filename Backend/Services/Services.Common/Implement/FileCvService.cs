using Core.CommonModel;
using Core.CommonModel.Enum;
using Database.Sql.ERP;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.Common.Interfaces;
using Services.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using File = Database.Sql.ERP.Entities.Common.File;

namespace Services.Common.Implement
{
    public class FileCvService : IFileCvService
    {
        private readonly IERPUnitOfWork _context;
        private IHttpContextAccessor _httpContext;

        public FileCvService(IERPUnitOfWork context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                File md = _context.FileCVRepository.FirstOrDefault(x => x.Id == id && !x.Deleted);

                md.Deleted = true;
                md.UpdateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                md.UpdateDate = DateTime.Now;

                _context.FileCVRepository.Update(md);

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
                var query = from f in _context.FileCVRepository.Query()
                            join c in _context.CadidateRepository.Query()
                            on f.CadidateId equals c.CadidateId
                            where !f.Deleted && !c.Deleted
                            orderby c.Name
                            select new FileCvViewModel()
                            {
                                Name = c.Name,
                                FileName = f.FileName,
                                FileType = f.FileType,
                                FileSize = f.FileSize,
                                CreateDate = f.CreateDate
                            };
                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(x => x.Name.ToLower().Contains(filter.Text.ToLower())
                                        || x.FileName.ToLower().Contains(filter.Text.ToLower()));
                }

                BaseListModel<FileCvViewModel> listItems = new BaseListModel<FileCvViewModel>();

                listItems.Items = await query.Skip((filter.Paging.PageIndex - 1) * filter.Paging.PageSize)
                                        .Take(filter.Paging.PageSize)
                                        .OrderByDescending(x=>x.Name)
                                        .ToListAsync()
                                        .ConfigureAwait(true);

                listItems.TotalItems = await query.CountAsync();

                response.Result = listItems;
                response.Result = ResponseStatus.Success;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public Task<ResponseModel> Insert(FileCvViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> Item(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                File md = await _context.FileCVRepository.FirstOrDefaultAsync(x => x.CadidateId == id && !x.Deleted && x.FileType == ".pdf");

                FileCvViewModel model = new FileCvViewModel();

                model.FileName = md.FileName;
                model.FilePath = Path.Combine(Path.Combine("wwwroot/cadidate-cv"), md.FilePath);
                model.CadidateId = md.CadidateId;

                response.Result = model;
                response.Status = ResponseStatus.Success;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public Task<ResponseModel> Update(FileCvViewModel model)
        {
            throw new NotImplementedException();
        }

    }
}
