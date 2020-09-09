using Core.CommonModel;
using Core.CommonModel.Enum;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        public async Task<ResponseModel> Insert(RoleViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Role md = new Role();

                md.Name = model.Name;
                md.Description = model.Description;
                md.Deleted = false;
                md.CreateDate = DateTime.Now;
                md.CreateBy = 1;

                await _context.RoleRepository.AddAsync(md);

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
                Role md = await _context.RoleRepository.FirstOrDefaultAsync(x => x.RoleId == id && !x.Deleted);

                if (md == null)
                {
                    throw new Exception();
                }

                RoleViewModel model = new RoleViewModel()
                {
                    Name = md.Name,
                    Description = md.Description,
                    CreateDate = md.CreateDate
                };

                response.Result = model;
                response.Status = ResponseStatus.Success;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Update(RoleViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Role md = _context.RoleRepository.FirstOrDefault(x => x.RoleId == model.RoleId && !x.Deleted);

                if (md == null)
                {
                    throw new Exception();
                }

                md.Name = model.Name;
                md.Description = model.Description;
                md.UpdateDate = DateTime.Now;
                md.UpdateBy = 1;

                _context.RoleRepository.Update(md);

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
