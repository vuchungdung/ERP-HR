using Core.CommonModel;
using Core.CommonModel.Enum;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.System;
using Microsoft.AspNetCore.Http;
using Services.System.Interfaces;
using Services.System.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.System.Implement
{
    public class RoleService : IRoleService
    {
        private readonly IERPUnitOfWork _context;
        private IHttpContextAccessor _httpContext;

        public RoleService(IERPUnitOfWork context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public async Task<ResponseModel> Delete(RoleViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Role md = _context.RoleRepository.FirstOrDefault(x => x.RoleId == model.RoleId);

                md.Deleted = true;
                md.UpdateBy = 1;
                md.UpdateDate = DateTime.Now;

                _context.RoleRepository.Update(md);

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

        public Task<ResponseModel> GetList(FilterModel filter)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Insert(RoleViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Item(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(RoleViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
