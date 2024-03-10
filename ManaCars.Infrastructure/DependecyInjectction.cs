using ManaCars.Application.Common.Interfaces.Authentication;
using ManaCars.Application.Common.Interfaces.Persistence;
using ManaCars.Application.Common.Interfaces.Services;
using ManaCars.Infrastructure.Authentication;
using ManaCars.Infrastructure.Persistence;
using ManaCars.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ManaCars.Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}