using Microsoft.AspNetCore.Http;

namespace Artalex.BLL.Services.TenantService;

public class TenantService : ITenantService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public TenantService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetTenantId()
    {
        // Example: read from claims
        var tenantClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("tenant_id")?.Value;

        if (tenantClaim == null)
            throw new UnauthorizedAccessException("Tenant not found");

        return tenantClaim;
    }
}