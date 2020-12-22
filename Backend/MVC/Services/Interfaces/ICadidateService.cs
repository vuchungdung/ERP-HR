using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Services.Interfaces
{
    public interface ICandidateService
    {
        bool Regrister(RegisterViewModel model);
        List<ManageJobViewModel> Get(int Id);

        bool Login(LoginViewModel model);

        bool CreateProfile(CandidateViewModel model);

        bool AddFile(FileViewModel model);
        bool Apply(ApplyViewModel model);
        CandidateViewModel GetByUsername(string username);
        CandidateViewModel GetDetail(int id);

    }
}
