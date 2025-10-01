// Artalex.API/Controllers/AuthController.cs

using Ardalis.Result;
using Artalex.BLL.Services.AuthService;
using Artalex.DTO.LoginDtos;
using Microsoft.AspNetCore.Mvc;

namespace Artalex.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<Result<LoginResultDto>> Login([FromBody] LoginDto dto)
    {
         return await _authService.LoginAsync(dto);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await _authService.LogoutAsync();
        return Ok("Logged out successfully");
    }
}