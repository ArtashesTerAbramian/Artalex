using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Artalex.BLL.Services.ContextModificatorService;
using Artalex.BLL.Services.ErrorService;
using Artalex.BLL.Services.TenantService;
using Artalex.DAL;

namespace Artalex.BLL;

public static class ServiceExtension
{
    public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IContextModificatorService, ContextModificatorService>();
        services.AddScoped<IErrorService, ErrorService>();
        services.AddScoped<ITenantService, TenantService>();
        
        return services;
    }
}