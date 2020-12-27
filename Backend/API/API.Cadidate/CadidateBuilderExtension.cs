using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Cadidates.Implement;
using Services.Cadidates.Interfaces;
using Services.Candidates.Implement;
using Services.Candidates.Interfaces;

namespace API.Candidate
{
    public static class CandidateBuilderExtension
    {
        public static IServiceCollection AddCandidateServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ICandidateService, CandidateService>();
            services.AddScoped<IWorkHistoryService, WorkHistoryService>();
            services.AddScoped<IEducationService, EducationService>();
            services.AddScoped<IAwardService, AwardService>();
            return services;
        }
    }
}