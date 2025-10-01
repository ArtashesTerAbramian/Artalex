// Artalex.Application/Services/TenantService.cs

using Artalex.DAL;
using Artalex.DAL.Models;
using Artalex.DTO.TenantDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Artalex.BLL.Services.TenantService;

public class TenantService : ITenantService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public string Name { get; set; }
    private readonly AppDbContext _dbContext;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;

    public TenantService(AppDbContext dbContext,
        UserManager<User> userManager,
        RoleManager<Role> roleManager,
        IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _roleManager = roleManager;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TenantDto> CreateTenantAsync(CreateTenantDto dto)
    {
        var tenant = new Tenant
        {
            Name = dto.Name,
            TenancyName = dto.TenancyName,
            IsActive = true,
            ConnectionString = dto.ConnectionString
        };

        _dbContext.Tenants.Add(tenant);
        await _dbContext.SaveChangesAsync();

        // create roles
        var adminRole = new Role { Name = "Admin", NormalizedName = "ADMIN" };
        await _roleManager.CreateAsync(adminRole);

        // create admin user
        var adminUser = new User
        {
            UserName = dto.AdminEmailAddress,
            Email = _userManager.NormalizeEmail(dto.AdminEmailAddress),
            TenantId = tenant.Id
        };

        await _userManager.CreateAsync(adminUser, "123qwe"); // default password
        await _userManager.AddToRoleAsync(adminUser, "Admin");

        return new TenantDto
        {
            Id = tenant.Id,
            Name = tenant.Name,
            TenancyName = tenant.TenancyName,
            IsActive = tenant.IsActive
        };
    }

    public string TenantName
    {
        get
        {
            // Get tenant ID from claims
            var claim = _httpContextAccessor.HttpContext?.User?.FindFirst("tenantName");
            if (claim == null) throw new Exception("Tenant ID not found in claims");
            return claim.Value;
        }
    }
    
    public async Task<List<TenantDto>> GetAllAsync(string? keyword = null)
    {
        return await _dbContext.Tenants
            .Where(t => string.IsNullOrEmpty(keyword) || t.Name.Contains(keyword) || t.TenancyName.Contains(keyword))
            .Select(t => new TenantDto
            {
                Id = t.Id,
                Name = t.Name,
                TenancyName = t.TenancyName,
                IsActive = t.IsActive
            })
            .ToListAsync();
    }
}