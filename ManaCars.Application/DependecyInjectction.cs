using ManaCars.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace ManaCars.Application;

public static class DependecyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}