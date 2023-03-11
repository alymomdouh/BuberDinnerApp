using BuberDinnerApp.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace BuberDinnerApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();


            return services;
        }
    }
}
