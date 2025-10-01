// Artalex.Application/Services/UserService.cs

using Ardalis.Result;
using Artalex.BLL.Services.MailService;
using Artalex.DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace Artalex.BLL.Services.UserService;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly IMailService _emailSender; // custom email sender

    public UserService(UserManager<User> userManager, IMailService emailSender)
    {
        _userManager = userManager;
        _emailSender = emailSender;
    }

    public async Task<Result<IdentityResult>> CreateUserAsync(string email, int? tenantId = null)
    {
        var user = new User
        {
            UserName = email,
            Email = email,
            TenantId = tenantId,
            EmailConfirmed = false
        };

        var result = await _userManager.CreateAsync(user);
        if (!result.Succeeded) return result;

        // generate reset password token
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        // build reset link (frontend route for password reset)
        var resetLink = $"/reset-password?userId={user.Id}&token={Uri.EscapeDataString(token)}";

        // send email
        await _emailSender.SendEmailAsync(email, "Welcome to Artalex",
            $"Hello, please set your password by clicking this link: <a href='{resetLink}'>Reset Password</a>");

        return result;
    }
}