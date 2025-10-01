using Ardalis.Result;
using Microsoft.AspNetCore.Identity;

namespace Artalex.BLL.Services.UserService;

public interface IUserService
{
    Task<Result<IdentityResult>> CreateUserAsync(string email, int? tenantId = null);
}