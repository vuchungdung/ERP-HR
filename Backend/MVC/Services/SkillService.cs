using MVC.Helper;
using MVC.Models;
using MVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Interfaces
{
    public class SkillService : ISkillService
    {
        private readonly IDatabaseHelper _helper;

        public SkillService(IDatabaseHelper helper)
        {
            _helper = helper;
        }
        public List<SkillViewModel> GetAllSkill()
        {
            try
            {
                var dt = _helper.ExecuteSProcedure("SP_Skill_GET_ALL");
                var listItems = dt.ConvertTo<SkillViewModel>().ToList();
                return listItems;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
