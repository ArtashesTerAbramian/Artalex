using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Artalex.DAL.Models;

public class User : IdentityUser<int>
{
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string? Messenger { get; set; }
    public string? MessengerPhoneNumber { get; set; }
    public string? AdditionalInfo { get; set; }
    public int? TenantId { get; set; }
    public Tenant Tenant { get; set; }

    // Navigation Properties
    public virtual ICollection<UserFile> Files { get; set; } = new List<UserFile>();

    // Helper Methods
    public static string CreateRandomPassword()
    {
        return Guid.NewGuid().ToString("N").Substring(0, 16);
    }

    public void SetNormalizedNames()
    {
        NormalizedUserName = UserName.ToUpperInvariant();
        NormalizedEmail = Email.ToUpperInvariant();
    }
  
}