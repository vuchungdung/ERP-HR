using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Candidates.Implement;
using Services.Candidates.Interfaces;

namespace API.Candidate
{
    public static class CandidateBuilderExtension
    {
        public static IServiceCollection AddCandidateServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ICandidateService, CandidateService>();
            return services;
        }
    }
}