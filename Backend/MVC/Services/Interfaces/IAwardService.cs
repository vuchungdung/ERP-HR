using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Services.Interfaces
{
    public interface IAwardService
    {
        bool Create(AwardsViewModel model);
        bool Update(AwardsViewModel model);
        bool Delete(int id);
        List<AwardsViewModel> GetByCId(int id);
    }
}
