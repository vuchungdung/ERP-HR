using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Recruitment.Implement;
using Services.Recruitment.Interface;

namespace API.Recruitment
{
    public static class RecruitmentBuilderExtension
    {
        public static IServiceCollection AddRecruitmentServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IJobDescriptionService, JobDescriptionService>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}