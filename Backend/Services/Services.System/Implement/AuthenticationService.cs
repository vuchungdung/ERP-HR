using Core.CommonModel;
using Core.CommonModel.Enum;
using Core.Services.InterfaceService;
using Core.Utility.Security;
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

        public async Task<ResponseModel> AuthencitateUser(LoginViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var password = PasswordSecurity.GetHashedPassword(model.Password);

                var md = await _context.UserRepository.FirstOrDefaultAsync(x => x.UserName == model.UserName
                                                                           && x.Password == password
                                                                           && !x.Deleted
                                                                           && x.isActive).ConfigureAwait(false);

                if(md != null)
                {
                    JwtTokenModel token = _tokenService.CreateToken(md);
                    response.Status = ResponseStatus.Success;
                    response.Result = token;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
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
