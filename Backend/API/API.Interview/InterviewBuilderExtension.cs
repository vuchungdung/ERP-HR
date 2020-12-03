using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Interview.Implement;
using Services.Interview.Interfaces;

namespace API.Interview
{
    public static class InterviewBuilderExtension
    {
        public static IServiceCollection AddInterviewServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IInterviewDateService, InterviewDateService>();
            return services;
        }
    }
}