﻿using MVC.Helper;
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

        public bool Apply(FileViewModel model)
        {
            try
            {
                var response = _helper.ExecuteSProcedure("SP_FILE_CREATE", "@CREATEDATE", DateTime.Now, "@DELETED", false, "@FILENAME",model.FileName, "@FILEPATH",model.FilePath, "@FILETYPE",model.FileType, "@FILESIZE",model.FileSize,"@CADIDATEID",model.CadidateId);
                if(response != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool CreateProfile(CadidateViewModel model)
        {
            try
            {
                var response = _helper.ExecuteSProcedure("");
                if(response != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Login(LoginViewModel model)
        {
            try
            {
                var response = _helper.ExecuteSProcedure("SP_CADIDATE_LOGIN", "@USERNAME", model.Username, "@PASSWORD", model.Password);
                if (response != null)
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
