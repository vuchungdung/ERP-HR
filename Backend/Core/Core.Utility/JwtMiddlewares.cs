using Core.Services.InterfaceService;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utility
{
    public class JwtMiddlewares
    {
        private readonly RequestDelegate _next;

        public JwtMiddlewares(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IJwtTokenSecurityService jwtTokenSerivice)
        {

        }
    }
}
