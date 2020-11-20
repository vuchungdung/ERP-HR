using Core.CommonModel;
using Core.CommonModel.Enum;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.System;
using Microsoft.AspNetCore.Http;
using Services.System.Interfaces;
using Services.System.ViewModel;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Utility.Security;

namespace Services.System.Implement
{
    public class UserService : IUserService
    {
        private readonly IERPUnitOfWork _context;
        private IHttpContextAccessor _httpContext;

        public UserService(IERPUnitOfWork context,IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                User md = _context.UserRepository.FirstOrDefault(x => x.UserId == id && !x.Deleted);

                md.Deleted = true;
                md.UpdateDate = DateTime.Now;
                md.UpdateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                md.isActive = false;

                _context.UserRepository.Update(md);
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
                var query = from m in _context.UserRepository.Query()
                            where !m.Deleted
                            orderby m.Name
                            select new UserViewModel()
                            {
                                UserId = m.UserId,
                                Name = m.Name,
                                Email = m.Email,
                                Phone = m.Phone,
                                Address = m.Address,
                                Image = m.Image,
                                UserName = m.UserName
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(x => x.Name.ToLower().Contains(filter.Text.ToLower())
                    || x.Email.ToLower().Contains(filter.Text.ToLower())
                    || x.Address.ToLower().Contains(filter.Text.ToLower())
                    || x.UserName.ToLower().Contains(filter.Text.ToLower()));
                }

                BaseListModel<UserViewModel> listItems = new BaseListModel<UserViewModel>();

                listItems.Items = await query.Skip((filter.Paging.PageIndex - 1) * filter.Paging.PageSize)
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

        public async Task<ResponseModel> Insert(UserViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                User md = new User();

                md.Name = model.Name;
                md.Address = model.Address;
                md.Email = model.Email;
                md.Phone = model.Phone;
                md.isActive = true;
                md.Deleted = false;
                md.UserName = model.UserName;
                md.Image = model.Image;
                md.Password = PasswordSecurity.GetHashedPassword(model.Password);
                md.CreateDate = DateTime.Now;

                await _context.UserRepository.AddAsync(md);

                await _context.SaveChangesAsync();

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
                User md = await _context.UserRepository.FirstOrDefaultAsync(x => x.UserId == id && !x.Deleted);

                if (md == null)
                {
                    throw new Exception();
                }

                UserViewModel model = new UserViewModel()
                {
                    UserId = md.UserId,
                    Name = md.Name,
                    Email = md.Email,
                    Phone = md.Phone,
                    Address = md.Address,
                    Image = md.Image,
                    UserName = md.UserName,
                    isActive = md.isActive
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

        public async Task<ResponseModel> Update(UserViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                User md = _context.UserRepository.FirstOrDefault(x => x.UserId == model.UserId);

                md.Name = model.Name;
                md.Address = model.Address;
                md.Email = model.Email;
                md.Phone = model.Phone;
                md.UserName = model.UserName;
                md.Image = model.Image;
                md.isActive = model.isActive;
                md.Password = PasswordSecurity.GetHashedPassword(model.Password);
                md.UpdateDate = DateTime.Now;
                md.UpdateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                _context.UserRepository.Update(md);
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
