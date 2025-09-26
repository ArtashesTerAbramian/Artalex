using Artalex.DAL;

namespace Artalex.BLL.Services.ContextModificatorService;

public class ContextModificatorService : IContextModificatorService
{
    public bool IsGlobalQueryFiltersEnable { get; } = true;
}