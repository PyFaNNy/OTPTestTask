using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestWebApi.Application.Interfaces;

namespace TestWebApi.Persistence;

public static class DependenciesBootstrapper
{
    /// <summary>
    /// Extension IServiceCollection
    /// Add DbContext and DI Scoped lifecycle IAppDbContext
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            var connectinString = configuration.GetConnectionString("DefaultConnection");
            options.UseMySql(connectinString, ServerVersion.AutoDetect(connectinString),
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));

            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging();
        });

        services.AddScoped<IAppDbContext>(provider => provider.GetService<AppDbContext>());

        return services;
    }
}