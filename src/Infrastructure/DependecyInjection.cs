using Domain.Repositories;
using Domain.Repositories.User;
using Domain.Security.Cryptography;
using Domain.Security.Tokens;
using Infrastructure.Data;
using Infrastructure.Data.Interceptors;
using Infrastructure.Data.Repositories;
using Infrastructure.Security;
using Infrastructure.Security.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddToken(services, configuration);
        AddRepositories(services);

        services.AddScoped<IPasswordEncripter, Cryptography>();
        
        return services;
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Postgres");

        services.AddDbContext<FinancesDbContext>((serviceProvider, config) =>
        {
            var interceptor = serviceProvider.GetRequiredService<ISaveChangesInterceptor>();
            config.AddInterceptors(interceptor);
            config.UseNpgsql(connectionString);
        });
    }

    private static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");
        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<IAccessTokenGenerator>(_=> new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
    }
    
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();

        services.AddSingleton(TimeProvider.System);
    }
}