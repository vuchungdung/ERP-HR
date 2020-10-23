using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Cadidates.Implement;
using Services.Cadidates.Interfaces;

namespace API.Cadidate
{
    public static class CadidateBuilderExtension
    {
        public static IServiceCollection AddCadidateServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ICadidateService, CadidateService>();
            return services;
        }
    }
}