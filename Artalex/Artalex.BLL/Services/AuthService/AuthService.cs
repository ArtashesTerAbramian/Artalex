using Artalex.DAL.Models;
using Artalex.DTO.LoginDtos;
using Microsoft.EntityFrameworkCore;
using Ardalis.Result;


namespace Artalex.BLL.Services.AuthService;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

public class AuthService : IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<User> userManager,
                       SignInManager<User> signInManager,
                       IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async Task<Result<LoginResultDto>> LoginAsync(LoginDto dto)
    {
        var normalizedEmail = _userManager.NormalizeEmail(dto.Email);

        var user = await _userManager.Users
            .Include(x => x.Tenant)
            .FirstOrDefaultAsync(u => u.Email == normalizedEmail);

        if (user == null) return Result.Unauthorized();

        var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
        if (!result.Succeeded) return null;

        var roles = await _userManager.GetRolesAsync(user);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email ?? ""),
            new Claim(ClaimTypes.Name, user.UserName ?? ""),
            new Claim("tenantId", user.TenantId?.ToString() ?? ""),
            new Claim("tenantName", user.Tenant?.TenancyName ?? "")
        };

        claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.UtcNow.AddHours(2);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Issuer"],
            claims: claims,
            expires: expiration,
            signingCredentials: creds
        );

        return Result.Success(new LoginResultDto
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        });
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync(); // just for cookie-based auth, JWT is stateless
    }
}
