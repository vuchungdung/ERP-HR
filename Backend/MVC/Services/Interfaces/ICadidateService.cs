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

        bool Login(LoginViewModel model);

        bool CreateProfile(CandidateViewModel model);

        bool Apply(FileViewModel model);

        CandidateViewModel GetByUsername(string username);
    }
}
