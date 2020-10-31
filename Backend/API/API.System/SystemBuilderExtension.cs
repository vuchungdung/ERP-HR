using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.System.Implement;
using Services.System.Interfaces;

namespace API.System
{
    public static class SystemBuilderExtension
    {
        public static IServiceCollection AddSystemServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}