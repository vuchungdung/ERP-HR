using Core.CommonModel.Enum;
using MVC.Helper;
using MVC.Models;
using MVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MVC.Services
{
    public class JobDescriptionService : IJobDescriptionService
    {
        private readonly IDatabaseHelper _helper;

        public JobDescriptionService(IDatabaseHelper helper)
        {
            _helper = helper;
        }

        public PageResult<JobDescriptionViewModel> GetJobPaging(PageViewModel model)
        {
            try
            {
                var dt = _helper.ExecuteSProcedure("SP_JOBDESCRIPTION_GET_PAGING","@PAGESIZE",model.Pagesize,"@PAGE",model.Page);
                var listItems = dt.ConvertTo<JobDescriptionViewModel>().ToList();
                if (!String.IsNullOrEmpty(model.Keyword))
                {
                    listItems = listItems.Where(x => x.Title.ToLower().Contains(model.Keyword.ToLower())
                                            ||x.SkillId.ToLower().Contains(model.Keyword.ToLower())
                                            ||x.Name.ToLower().Contains(model.Keyword.ToLower())).ToList();
                }
                if(model.Categoryid != null)
                {
                    listItems = listItems.Where(x => x.CategoryId == model.Categoryid).ToList();
                }
                if(model.Type != null)
                {
                    listItems = listItems.Where(x => x.Type == model.Type).ToList();
                }
                var pagination = new PageResult<JobDescriptionViewModel>()
                {
                    ListItems = listItems,
                    TotalRecords = listItems.Count()
                };
                return pagination;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}