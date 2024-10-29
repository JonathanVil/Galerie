using Galerie.Application.Common.Interfaces;
using Galerie.Infrastructure.Data;
using Galerie.Web.Configurator.Services;
using Microsoft.AspNetCore.Mvc;

namespace Galerie.Web.Configurator;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped<IUser, CurrentUser>();

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        // services.AddExceptionHandler<CustomExceptionHandler>();
        
        return services;
    }

    // public static IServiceCollection AddKeyVaultIfConfigured(this IServiceCollection services, ConfigurationManager configuration)
    // {
    //     var keyVaultUri = configuration["AZURE_KEY_VAULT_ENDPOINT"];
    //     if (!string.IsNullOrWhiteSpace(keyVaultUri))
    //     {
    //         configuration.AddAzureKeyVault(
    //             new Uri(keyVaultUri),
    //             new DefaultAzureCredential());
    //     }
    //
    //     return services;
    // }
}
