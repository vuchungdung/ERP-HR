using MVC.Helper;
using MVC.Models;
using MVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Services
{
    public class CadidateUserService : ICadidateUserService
    {
        private readonly IDatabaseHelper _helper;
        public CadidateUserService(IDatabaseHelper helper)
        {
            _helper = helper;
        }
        public LoginViewModel Login(LoginViewModel model)
        {
            try
            {
                var dt = _helper.ExecuteSProcedure("SP_CADIDATE_USER_LOGIN",
                    "@USERNAME", model.Username,
                    "@PASSWORD", model.Password);
                var result = dt.Select().ElementAt(0).GetItem<LoginViewModel>();
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public LoginViewModel Register(RegisterViewModel model)
        {
            try
            {
                var dt = _helper.ExecuteSProcedure("SP_CADIDATE_USER_REGISTER",
                    "@USERNAME", model.Username,
                    "@PASSWORD", model.Password);
                var result = new LoginViewModel()
                {
                    Username = model.Username,
                    Password = model.Password
                };
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
