namespace Artalex.BLL.Models;

public class MailServiceOptions
{
    public string SMTP { get; set; }
    public int Port { get; set; }
    public string UserName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FromName { get; set; } = null!;
    public string FromEmail { get; set; } = null!;
    public string ToName { get; set; } = null!;
    public bool SSL { get; set; }
}