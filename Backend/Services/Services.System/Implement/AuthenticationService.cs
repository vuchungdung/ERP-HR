using Core.CommonModel;
using Core.Services.InterfaceService;
using Database.Sql.ERP;
using Services.System.Interfaces;
using Services.System.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.System.Implement
{
    public class AuthenticationService : IAuthenticationService
    {
        private IJwtTokenSecurityService _tokenService;
        private IERPUnitOfWork _context;

        public AuthenticationService(IJwtTokenSecurityService tokenService, IERPUnitOfWork context)
        {
            _tokenService = tokenService;
            _context = context;
        }

        public Task<ResponseModel> AuthencitateUser(LoginViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> RefreshToken(TokenModel model)
        {
            throw new NotImplementedException();
        }

        public ResponseModel RevokeToken(TokenModel model)
        {
            throw new NotImplementedException();
        }
    }
}
