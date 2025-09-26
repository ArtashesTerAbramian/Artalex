using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Artalex.DAL.Models;

 public class User : BaseEntity
    {
        public const string DefaultPassword = "123qwe";

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        public string UserName { get; set; } = null!;

        [Required]
        [MaxLength(256)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(256)]
        public string Surname { get; set; } = null!;

        [Required]
        [MaxLength(256)]
        public string EmailAddress { get; set; } = null!;

        [MaxLength(256)]
        public string? Messenger { get; set; }

        [MaxLength(50)]
        public string? MessengerPhoneNumber { get; set; }

        public string? AdditionalInfo { get; set; }

        [MaxLength(256)]
        public string? NormalizedUserName { get; set; }

        [MaxLength(256)]
        public string? NormalizedEmailAddress { get; set; }

        [Required]
        [MaxLength(128)]
        public string Password { get; set; } = DefaultPassword;

        // Foreign Key for Tenant (optional)
        public int? TenantId { get; set; }

        // Navigation Properties
        public virtual ICollection<UserFile> Files { get; set; } = new List<UserFile>();
        public virtual ICollection<UserRole> Roles { get; set; } = new List<UserRole>();

        // Helper Methods
        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 16);
        }

        public void SetNormalizedNames()
        {
            NormalizedUserName = UserName.ToUpperInvariant();
            NormalizedEmailAddress = EmailAddress.ToUpperInvariant();
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress, string adminUserName = "Admin")
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = adminUserName,
                Name = adminUserName,
                Surname = adminUserName,
                EmailAddress = emailAddress,
            };

            user.SetNormalizedNames();

            return user;
        }
    }