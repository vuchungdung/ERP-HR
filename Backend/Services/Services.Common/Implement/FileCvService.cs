using Core.CommonModel;
using Core.CommonModel.Enum;
using Database.Sql.ERP;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.Common.Interfaces;
using Services.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

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

        public Task<ResponseModel> Delete(FileCvViewModel model)
        {
            throw new NotImplementedException();
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
        public Task<ResponseModel> Item(int id)
        {
            throw new NotImplementedException();
        }

        /*
         -------------------------------------------------------
         */
        public Task<ResponseModel> Insert(FileCvViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(FileCvViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
