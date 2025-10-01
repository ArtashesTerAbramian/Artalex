using Artalex.DAL;
using Microsoft.EntityFrameworkCore;

namespace Artalex.BLL.Services.MailService;

public class MailSenderService : IMailSenderService
{
    private readonly AppDbContext _db;
    private readonly IMailService _mailService;

    public MailSenderService(AppDbContext db,
        IMailService mailService)
    {
        _db = db;
        _mailService = mailService;
    }

    public async Task SendEmails()
    {
        var mails = await _db.MailQueues
            .Where(x => x.IsSent != true &&
                        x.FailedCount < 5)
            .ToListAsync();

        foreach (var mail in mails)
        {
            if (!string.IsNullOrEmpty(mail.Text) &&
                await _mailService.SendEmailAsync(mail.Contact, mail.Subject, mail.Text))
            {
                mail.IsSent = true;
            }
            else
            {
                mail.FailedCount++;
            }

            await _db.SaveChangesAsync();
        }
    }
}