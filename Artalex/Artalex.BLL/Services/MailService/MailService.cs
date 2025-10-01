using System.Security.Authentication;
using Artalex.BLL.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Artalex.BLL.Services.MailService;

public class MailService : IMailService
{
    private readonly ILogger<MailService> _logger;
    private readonly MailServiceOptions _options;

    public MailService(IOptions<MailServiceOptions> options, ILogger<MailService> logger)
    {
        _options = options.Value;
        _logger = logger;
    }

    public async Task<bool> SendEmailAsync(string email, string subject, string message)
    {
        var mail = new MimeMessage();
        mail.From.Add(new MailboxAddress(_options.FromName, _options.FromEmail));
        mail.To.Add(new MailboxAddress(_options.ToName, email));
        mail.Subject = subject;

        var body = new BodyBuilder
        {
            HtmlBody = message
        };

        mail.Body = body.ToMessageBody();

        try
        {
            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.CheckCertificateRevocation = false;
                client.SslProtocols = SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;

                await client.ConnectAsync(_options.SMTP, _options.Port, _options.SSL).ConfigureAwait(false);
                await client.AuthenticateAsync(_options.UserName, _options.Password).ConfigureAwait(false);

                await client.SendAsync(mail).ConfigureAwait(false);
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, $"SendingEmailError: {email}");
        }

        return false;
    }
}