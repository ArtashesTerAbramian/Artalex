using Microsoft.EntityFrameworkCore;

namespace Artalex.DAL;

public class AppDbContextFactory : DesignTimeDbContextFactory<AppDbContext>
{
    private readonly IContextModificatorService _contextModificatorService;

    public AppDbContextFactory()
    {
    }

    public AppDbContextFactory(IContextModificatorService contextModificatorService, IServiceProvider serviceProvider)
    {
        _contextModificatorService = contextModificatorService;
    }

    protected override AppDbContext CreateNewInstance(DbContextOptions<AppDbContext> options)
    {
        return new AppDbContext(options, _contextModificatorService);
    }
}