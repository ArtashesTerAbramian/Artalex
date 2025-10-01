namespace Artalex.BLL.Services.MailService;

public interface IMailService
{
    Task<bool> SendEmailAsync(string email, string subject, string message);
}