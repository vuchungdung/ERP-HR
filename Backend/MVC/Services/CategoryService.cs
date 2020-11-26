using MVC.Helper;
using MVC.Models;
using MVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Interfaces
{
    public class CategoryService : ICategoryService
    {
        private readonly IDatabaseHelper _helper;
        
        public CategoryService(IDatabaseHelper helper)
        {
            _helper = helper;
        }

        public List<CategoryViewModel> GetAll()
        {
            try
            {
                var dt = _helper.ExecuteSProcedure("SP_CATEGORY_GET_ALL");
                var listItems = dt.ConvertTo<CategoryViewModel>().ToList();
                return listItems;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
