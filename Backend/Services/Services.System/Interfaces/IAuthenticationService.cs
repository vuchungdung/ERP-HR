using Core.CommonModel;
using Services.System.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.System.Interfaces
{
    public interface IAuthenticationService
    {
        Task<ResponseModel> AuthencitateUser(LoginViewModel model);

        Task<ResponseModel> RefreshToken(TokenModel model);

        ResponseModel RevokeToken(TokenModel model);
    }
}
