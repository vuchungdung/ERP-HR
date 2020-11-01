using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Services.Interfaces
{
    public interface ICadidateUserService
    {
        LoginViewModel Register(RegisterViewModel model);
        LoginViewModel Login(LoginViewModel model);
    }
}
