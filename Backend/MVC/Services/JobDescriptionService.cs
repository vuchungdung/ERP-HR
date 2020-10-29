using MVC.Helper;
using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Services
{
    public class JobDescriptionService
    {
        private readonly IDatabaseHelper _dbHelper;

        public JobDescriptionService(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<JobDescriptionViewModel> GetJobPaging(int page, int pagesize, string keyword, int categoryid, int type)
        {
            try
            {
                var dt = _dbHelper.ExecuteSProcedure("SP_JOBDESCRIPTION_GET_PAGING",
                                                        "@PAGE", page,
                                                        "@PAGESIZE", pagesize,
                                                        "@KEYWORD", keyword,
                                                        "@CATEGORYID", categoryid,
                                                        "@TYPE", type);
                return dt.ConvertTo<JobDescriptionViewModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}