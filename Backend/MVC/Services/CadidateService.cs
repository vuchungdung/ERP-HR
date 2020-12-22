using MVC.Helper;
using MVC.Models;
using MVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly IDatabaseHelper _helper;

        public CandidateService(IDatabaseHelper helper)
        {
            _helper = helper;
        }

        public bool AddFile(FileViewModel model)
        {
            try
            {
                var response = _helper.ExecuteSProcedure("SP_FILE_CREATE", "@CREATEDATE", DateTime.Now, "@DELETED", false, "@FILENAME",model.FileName, "@FILEPATH",model.FilePath, "@FILETYPE",model.FileType, "@FILESIZE",model.FileSize,"@CANDIDATEID",model.CandidateId);
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

        public bool CreateProfile(CandidateViewModel model)
        {
            try
            {
                var response = _helper.ExecuteSProcedure("SP_CANDIDATE_UPDATE",
                                                            "@CANDIDATEID",model.CandidateId,
                                                            "@NAME",model.Name,
                                                            "@EMAIL",model.Email,
                                                            "@ADDRESS",model.Address,
                                                            "@PHONE",model.Phone,
                                                            "@DOB",model.Dob, 
                                                            "@GENDER",model.Gender,                                                           
                                                            "@SKYPE",model.Skype,
                                                            "@zalo",model.Zalo,
                                                            "@Facebook",model.Facebook,
                                                            "@Linkedin", model.LinkedIn);
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

        public CandidateViewModel GetByUsername(string username)
        {
            try
            {
                var response = _helper.ExecuteSProcedure("SP_GET_CANDIDATE_USERNAME", "@USERNAME", username);
                return response.ConvertTo<CandidateViewModel>().ToList().ElementAt(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Login(LoginViewModel model)
        {
            try
            {
                var response = _helper.ExecuteSProcedure("SP_CANDIDATE_LOGIN", "@USERNAME", model.Username, "@PASSWORD", model.Password);
                var result = response.ConvertTo<LoginViewModel>().ToList();
                if (result.Count != 0)
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

        public List<ManageJobViewModel> Get(int Id)
        {
            try
            {
                var response = _helper.ExecuteSProcedure("SP_GET_INTERVIEW", "ID", Id);
                return response.ConvertTo<ManageJobViewModel>().ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Regrister(RegisterViewModel model)
        {
            try
            {
                var response = _helper.ExecuteSProcedure("SP_CANDIDATE_REGRISTER", "@CREATEDATE",DateTime.Now,"@DELETED",false, "@USERNAME", model.Username, "@PASSWORD", model.Password);
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

        public CandidateViewModel GetDetail(int id)
        {
            try
            {
                var response = _helper.ExecuteSProcedure("SP_CANDIDATE_GET_DETAIL", "@ID", id);
                return response.ConvertTo<CandidateViewModel>().ToList().ElementAt(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Apply(ApplyViewModel model)
        {
            try
            {
                var response = _helper.ExecuteSProcedure("SP_APPLY_CREATE",
                                                         "@createby", model.CreateBy,
                                                         "@createdate", DateTime.Now,
                                                         "@candidateid", model.CandidateId,
                                                         "@jobid", model.JobId,
                                                         "@applydate", DateTime.Now);
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
    }
}
