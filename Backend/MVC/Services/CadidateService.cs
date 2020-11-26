using MVC.Helper;
using MVC.Models;
using MVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Services
{
    public class CadidateService : ICadidateService
    {
        private readonly IDatabaseHelper _helper;

        public CadidateService(IDatabaseHelper helper)
        {
            _helper = helper;
        }

        public bool Login(LoginViewModel model)
        {
            throw new NotImplementedException();
        }

        public bool Regrister(RegisterViewModel model)
        {
            try
            {
                var response = _helper.ExecuteSProcedure("SP_CADIDATE_REGRISTER", "@CREATEDATE",DateTime.Now,"@DELETED",false, "@USERNAME", model.Username, "@PASSWORD", model.Password);
                if(response != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
