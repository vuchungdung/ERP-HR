using Core.CommonModel;
using Core.CommonModel.Enum;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.Common;
using Microsoft.AspNetCore.Http;
using Services.Common.Interfaces;
using Services.Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<ResponseModel> Insert(TagViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Tag md = new Tag();

                md.Name = model.Name;
                md.Content = model.Content;
                md.Color = model.Color;

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

        public Task<ResponseModel> Item(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(TagViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
