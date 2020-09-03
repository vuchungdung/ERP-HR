using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Common.Implement;
using Services.Common.Interfaces;

namespace API.Common
{
    public static class CommonBuilderExtension
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ISkillService, SkillService>();
            return services;
        }
    } 
}
