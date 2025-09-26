using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artalex.DAL.Models
{
    public class Audit : BaseEntity
    {
        [Required]
        public long AuditorUserId { get; set; } // Foreign key to User entity

        [ForeignKey(nameof(AuditorUserId))]
        public virtual User Auditor { get; set; }
        public DateTime AuditDate { get; set; }

        [Required]
        public int VesselId { get; set; } // Foreign key to Vessel entity

        [ForeignKey(nameof(VesselId))]
        public virtual Vessel Vessel { get; set; }

        [Required]
        public int AuditStatusId { get; set; } // Foreign key to Status entity

        [ForeignKey(nameof(AuditStatusId))]
        public virtual AuditStatus AuditStatus { get; set; }

        [Required]
        public int AuditTypeId { get; set; } // Foreign key to Status entity

        [ForeignKey(nameof(AuditTypeId))]
        public virtual AuditType AuditType { get; set; }

        [Required]
        [MaxLength(100)]
        public string MasterName { get; set; }

        [Required]
        [MaxLength(100)]
        public string PortAgentName { get; set; }

        [MaxLength(20)]
        public string PortAgentPhone { get; set; }

        [EmailAddress]
        [MaxLength(100)]
        public string PortAgentEmail { get; set; }

        [Required]
        [MaxLength(100)]
        public string EmbarkationPort { get; set; }

        [Required]
        [MaxLength(100)]
        public string DisembarkationPort { get; set; }

        [Column(TypeName = "text")]
        public string Comment { get; set; }

        // Navigation Property: List of Attached Photos
        public virtual ICollection<AuditResponse> Responses { get; set; } = new List<AuditResponse>();
    }
}
