using Artalex.BLL.Helpers;
using Artalex.BLL.Models;
using Artalex.BLL.Services.AuthService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Artalex.BLL.Services.ContextModificatorService;
using Artalex.BLL.Services.ErrorService;
using Artalex.BLL.Services.MailService;
using Artalex.BLL.Services.SessionService;
using Artalex.BLL.Services.TenantService;
using Artalex.BLL.Services.UserService;
using Artalex.DAL;
using Microsoft.AspNetCore.Routing;

namespace Artalex.BLL;

public static class ServiceExtension
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IContextModificatorService, ContextModificatorService>();
        services.Configure<FileSettings>(options => configuration.GetSection(nameof(FileSettings)).Bind(options));
        services.Configure<LinkOptions>(options => configuration.GetSection(nameof(LinkOptions)).Bind(options));
        services.AddSingleton<FileHelper>();

 
        services.AddScoped<ITenantService, TenantService>();
        services.AddScoped<IErrorService, ErrorService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IMailService, MailService>();
        services.AddScoped<ISessionService, SessionService>();
        services.AddScoped<IUserService, UserService>();

        return services;
    }
}