using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Recruitment.Implement;
using Services.Recruitment.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Recruitment
{
    public static class RecruitmentBuilderExtension
    {
        public static IServiceCollection AddRecruitmentServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IJobDescriptionService, JobDescriptionService>();
            return services;
        }
    }
}
