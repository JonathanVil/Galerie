using Galerie.Application.Common.Interfaces;
using Galerie.Core.Constants;
using Galerie.Infrastructure.Data;
using Galerie.Infrastructure.Identity;
using Galerie.Web.Configurator.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Galerie.Web.Configurator;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);

        services.AddAuthorizationBuilder();

        services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI();

        services.AddSingleton(TimeProvider.System);
        services.AddTransient<IIdentityService, IdentityService>();

        services.AddAuthorization(options =>
            options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator)));
        
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
