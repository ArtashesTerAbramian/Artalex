using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Artalex.BLL.Services.TenantService;

public class TenantService : ITenantService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly string _defaultTenantId;

    public TenantService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
    {
        _httpContextAccessor = httpContextAccessor;

        _defaultTenantId = configuration.GetValue<string>("TenantSettings:DefaultTenantId") 
                           ?? throw new Exception("Default tenant ID is not configured.");
    }

    public string GetTenantId()
    {
        var tenantClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("tenant_id")?.Value;

        return tenantClaim ?? _defaultTenantId;
    }
}