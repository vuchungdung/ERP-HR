using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Services.Interfaces
{
    public interface IEducationService
    {
        bool Create(EducationViewModel model);
        bool Update(EducationViewModel model);
        bool Delete(int id);
        List<EducationViewModel> GetByCId(int id);
        EducationViewModel GetById(int id);
    }
}
