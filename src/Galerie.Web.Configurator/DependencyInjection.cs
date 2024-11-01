using Galerie.Application.Common.Interfaces;
using Galerie.Core.Constants;
using Galerie.Infrastructure.Data;
using Galerie.Infrastructure.Identity;
using Galerie.Web.Configurator.Components.Account;
using Galerie.Web.Configurator.Services;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;

namespace Galerie.Web.Configurator;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddAuthentication(o =>
            {
                o.DefaultScheme = IdentityConstants.ApplicationScheme;
                o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
            .AddIdentityCookies();

        if (config.GetSection("Authentication:Google").GetChildren().Any())
        {
            // get the google options
            var googleOptions = new GoogleOptions();
            config.GetSection("Authentication:Google").Bind(googleOptions);
            
            services.AddAuthentication()
                .AddGoogle(options => 
                {
                    options.ClientId = googleOptions.ClientId;
                    options.ClientSecret = googleOptions.ClientSecret;
                });
        }
        
        services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddRoles<ApplicationRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddSignInManager();
        
        services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

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
