using System.ComponentModel.DataAnnotations;

namespace Artalex.DAL.Models
{
    public class Vessel : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d{7}$", ErrorMessage = "IMO must be a 7-digit number.")]
        public string IMO { get; set; }

        public DateTime? LastAuditDate { get; set; }
        public DateTime? NextAuditDate { get; set; }
       
        [MaxLength(100)]
        public string? LastAuditorName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        // Navigation Property: List of Attached files
        public virtual ICollection<VesselFile> Files { get; set; } = new List<VesselFile>();
    }
}
