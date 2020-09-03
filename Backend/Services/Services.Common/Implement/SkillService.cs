using Core.CommonModel;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.Common;
using Microsoft.AspNetCore.Http;
using Services.Common.Interfaces;
using Services.Common.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Common.Implement
{
    public class SkillService : ISkillService
    {
        private readonly IERPUnitOfWork _context;
        private IHttpContextAccessor _httpContext;

        public SkillService(IERPUnitOfWork context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }
        public Task<ResponseModel> Delete(SkillViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> DropDownSelection()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> GetList(FilterModel filter)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Insert(SkillViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> Item(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Skill md = await _context.SkillRepository.FirstOrDefaultAsync();

                SkillViewModel model = new SkillViewModel()
                {
                    SkillId = md.SkillId,
                    Name = md.Name
                };
                response.Result = model;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public Task<ResponseModel> Update(SkillViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
