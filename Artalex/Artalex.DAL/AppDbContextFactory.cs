using Artalex.BLL.Services.TenantService;
using Microsoft.EntityFrameworkCore;

namespace Artalex.DAL;

public class AppDbContextFactory : DesignTimeDbContextFactory<AppDbContext>
{
    private readonly IContextModificatorService _contextModificatorService;

    public AppDbContextFactory()
    {
    }

    public AppDbContextFactory(IContextModificatorService contextModificatorService)
    {
        _contextModificatorService = contextModificatorService;
    }

    protected override AppDbContext CreateNewInstance(DbContextOptions<AppDbContext> options, ITenantService tenantService)
    {
        return new AppDbContext(options, _contextModificatorService, tenantService);
    }
}