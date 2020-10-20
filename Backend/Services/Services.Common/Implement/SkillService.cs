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
using System.Security.Claims;
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
        public async Task<ResponseModel> Delete(SkillViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Skill md = _context.SkillRepository.FirstOrDefault(x => x.SkillId == model.SkillId);

                md.Deleted = true;
                md.UpdateDate = DateTime.Now;
                md.UpdateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                _context.SkillRepository.Update(md);

                await _context.SaveChangesAsync();

                response.Status = ResponseStatus.Success;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> DropdownSelection()
        { 
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.SkillRepository.Query()
                            where !m.Deleted
                            orderby m.Name
                            select new SkillViewModel()
                            {
                                SkillId = m.SkillId,
                                Name = m.Name
                            };

                List<SkillViewModel> listItems = await query.ToListAsync();

                response.Result = listItems;
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
                var query = from m in _context.SkillRepository.Query()
                            where !m.Deleted
                            orderby m.Name
                            select new SkillViewModel()
                            {
                                SkillId = m.SkillId,
                                Name = m.Name,
                                
                            };
                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(x => x.Name.ToLower().Contains(filter.Text.ToLower()));
                }
                BaseListModel<SkillViewModel> listItems = new BaseListModel<SkillViewModel>();
                listItems.Items = await query
                    .Skip((filter.Paging.PageIndex - 1) * filter.Paging.PageSize)
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
        public List<Skill> GetListSkill(string id)
        {
            string[] arr = id.Split(',');
            List<Skill> result = new List<Skill>();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                Skill md = _context.SkillRepository.FirstOrDefault(x => x.SkillId == Convert.ToInt32(arr[i]));
                result.Add(md);
            }
            return result;
        }

        public async Task<ResponseModel> Insert(SkillViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Skill md = new Skill();

                md.Name = model.Name;
                md.CreateDate = DateTime.Now;
                md.CreateBy = 1;
                md.Deleted = false;

                await _context.SkillRepository.AddAsync(md);

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
                Skill md = await _context.SkillRepository.FirstOrDefaultAsync(x=>x.SkillId == id);

                if (md == null)
                {
                    throw new Exception();
                }

                SkillViewModel model = new SkillViewModel()
                {
                    SkillId = md.SkillId,
                    Name = md.Name
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

        public async Task<ResponseModel> Update(SkillViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Skill md = _context.SkillRepository.FirstOrDefault(x => x.SkillId == model.SkillId);

                md.Name = model.Name;
                md.UpdateDate = DateTime.Now;
                md.UpdateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                _context.SkillRepository.Update(md);

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
