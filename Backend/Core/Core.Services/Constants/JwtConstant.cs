using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Constants
{
    public class JwtConstant
    {
        public static readonly string TOKEN_LIFE_TIME = "Jwt:AccessTokenLifetime";

        public static readonly string SECRET_KEY = "Jwt:SecretKey";

        public static readonly string ISSUER = "Jwt:Issuer";

        public static readonly string AUDIENCE = "Jwt:Audience";
    }
}
