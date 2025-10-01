// Artalex.API/Controllers/AccountController.cs

using Artalex.DAL.Models;
using Artalex.DTO.UserDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Artalex.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly UserManager<User> _userManager;

    public AccountController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPassword(ResetPasswordDto dto)
    {
        var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
        if (user == null) return BadRequest("User not found.");

        var result = await _userManager.ResetPasswordAsync(user, dto.Token, dto.NewPassword);
        if (!result.Succeeded) return BadRequest(result.Errors);

        return Ok("Password has been reset successfully.");
    }
}