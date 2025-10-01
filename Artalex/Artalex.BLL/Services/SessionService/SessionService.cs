using Ardalis.Result;
using Artalex.DAL;
using Artalex.DAL.Models;
using Artalex.DTO.SessionDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Artalex.BLL.Services.SessionService;

public class SessionService : ISessionService
{
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _dbContext;

    public SessionService(UserManager<User> userManager,
        IHttpContextAccessor httpContextAccessor,
        AppDbContext dbContext)
    {
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
        _dbContext = dbContext;
    }

    public async Task<Result<GetCurrentLoginInfoDto>> GetCurrentLoginInfoAsync()
    {
        var userIdStr = _userManager.GetUserId(_httpContextAccessor.HttpContext?.User);
        if (userIdStr == null) return Result.SuccessWithMessage("No session found");

        var userId = int.Parse(userIdStr);
        var user = await _userManager.Users.Include(u => u.Tenant).FirstOrDefaultAsync(u => u.Id == userId);

        return Result.Success(new GetCurrentLoginInfoDto
        {
            User = new UserLoginInfoDto
            {
                Id = user!.Id,
                UserName = user.UserName!,
                Email = user.Email!
            },
            Tenant = user.Tenant != null
                ? new TenantLoginInfoDto { Id = user.Tenant.Id, Name = user.Tenant.Name }
                : null
        });
    }
}