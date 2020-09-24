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
using System.Threading.Tasks;

namespace Services.Common.Implement
{
    public class ProviderService : IProcessService
    {
        private readonly IERPUnitOfWork _context;
        private IHttpContextAccessor _httpContext;

        public ProviderService(IERPUnitOfWork context,IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }
        public Task<ResponseModel> Delete(ProcessViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> DropdowmSelection()
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
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public Task<ResponseModel> GetList(FilterModel filter)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Insert(ProcessViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Item(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(ProcessViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
