using Core.CommonModel;
using Database.Sql.ERP;
using Microsoft.AspNetCore.Http;
using Services.Recruitment.Interface;
using Services.Recruitment.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Core.CommonModel.Enum;
using Database.Sql.ERP.Entities.Recruitment;

namespace Services.Recruitment.Implement
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IERPUnitOfWork _context;
        private IHttpContextAccessor _httpContext;


        public EmployeeService(IERPUnitOfWork context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public Task<ResponseModel> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> DropdownSelection()
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.EmployeeRepository.Query()
                            where !m.Deleted
                            orderby m.CreateDate descending
                            select new EmployeeViewModel()
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Email = m.Email,
                                Address = m.Address,
                                Dob = m.Dob,
                                Phone = m.Phone,
                                Position = m.Position,
                                Gender = m.Gender
                            };

                var listItems = await query.ToListAsync();

                response.Result = listItems;
                response.Status = ResponseStatus.Success;
            }
            catch (Exception ex)
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
                var query = from m in _context.EmployeeRepository.Query()
                            where !m.Deleted
                            orderby m.CreateDate descending
                            select new EmployeeViewModel()
                            {
                                Id = m.Id,
                                Name = m.Name,
                                Email = m.Email,
                                Address = m.Address,
                                Dob = m.Dob,
                                Phone = m.Phone,
                                Position = m.Position,
                                Gender = m.Gender
                            };
                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(x => x.Name.ToLower().Contains(filter.Text.ToLower()));
                }
                BaseListModel<EmployeeViewModel> listItems = new BaseListModel<EmployeeViewModel>();
                listItems.Items = await query.Skip((filter.Paging.PageIndex - 1) * filter.Paging.PageSize)
                                                .Take(filter.Paging.PageSize)
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

        public async Task<ResponseModel> Insert(EmployeeViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Employee md = new Employee();

                md.Id = model.Id;
                md.Name = model.Name;
                md.Email = model.Email;
                md.Address = model.Address;
                md.Dob = model.Dob;
                md.Phone = model.Phone;
                md.Position = model.Position;
                md.Gender = model.Gender;

                await _context.EmployeeRepository.AddAsync(md);

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

        public Task<ResponseModel> Update(EmployeeViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
