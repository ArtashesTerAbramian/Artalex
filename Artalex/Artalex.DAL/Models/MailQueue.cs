namespace Artalex.DAL.Models;

public class MailQueue : BaseEntity
{
    public int UserId { get; set; }
    public bool IsSent { get; set; }
    public int FailedCount { get; set; }
    public string Subject { get; set; } = default!;
    public string Text { get; set; } = default!;
    public string Contact { get; set; } = default!;

    public User? User { get; set; }
}