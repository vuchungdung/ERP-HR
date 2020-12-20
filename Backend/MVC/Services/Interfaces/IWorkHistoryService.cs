using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Services.Interfaces
{
    public interface IWorkHistoryService
    {
        bool Create(WorkHistoryViewModel model);
        bool Update(WorkHistoryViewModel model);
        bool Delete(int id);
        List<WorkHistoryViewModel> GetByCId(int id);
    }
}
