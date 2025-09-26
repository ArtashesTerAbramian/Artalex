using Microsoft.AspNetCore.Mvc;

namespace Artalex.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    public ApiControllerBase()
    {
    }
}