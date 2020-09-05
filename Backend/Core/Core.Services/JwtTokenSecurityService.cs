using Core.CommonModel;
using Core.Services.Constants;
using Core.Services.InterfaceService;
using Database.Sql.ERP.Entities.System;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Core.Services
{
    public class JwtTokenSecurityService : IJwtTokenSecurityService
    {
        public IConfiguration _configuration;

        public JwtTokenSecurityService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public TokenModel CheckRefreshToken(TokenModel refreshTokenModel)
        {
            throw new NotImplementedException();
        }

        public JwtTokenModel CreateToken(User user)
        {
            try
            {
                var jwtSecurityToken = GetJwtSecurityToken(user);

                var token = new JwtTokenModel
                {
                    AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                    Expiration = jwtSecurityToken.ValidTo.ToLocalTime().Ticks,
                    RefreshToken = GenerateRefreshToken(),
                    UserName = user.UserName,
                };

                return token;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RevokeToken(TokenModel token)
        {
            throw new NotImplementedException();
        }

        public bool ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration[JwtConstant.SECRET_KEY]));
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                Console.WriteLine(jwtToken);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private JwtSecurityToken GetJwtSecurityToken(User user)
        {
            var accessTokenLifeTimeValue = double.Parse(_configuration[JwtConstant.TOKEN_LIFE_TIME]);

            var now = DateTime.UtcNow;
            var accessTokenLifetime = now.AddMinutes(accessTokenLifeTimeValue);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration[JwtConstant.SECRET_KEY]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                                        issuer: this._configuration[JwtConstant.ISSUER],
                                        audience: this._configuration[JwtConstant.AUDIENCE],
                                        claims: claims,
                                        notBefore: now,
                                        expires: accessTokenLifetime,
                                        signingCredentials: creds);
        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
