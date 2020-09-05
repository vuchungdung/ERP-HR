using Core.CommonModel;
using Database.Sql.ERP.Entities.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.InterfaceService
{
    public interface IJwtTokenSecurityService
    {
        JwtTokenModel CreateToken(User user);

        TokenModel CheckRefreshToken(TokenModel refreshTokenModel);

        bool RevokeToken(TokenModel token);

        bool ValidateToken(string token);
    }
}
