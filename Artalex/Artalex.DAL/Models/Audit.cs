using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artalex.DAL.Models
{
    public class Audit : BaseEntity
    {
        public int AuditorUserId { get; set; } // Foreign key to User entity

        public virtual User Auditor { get; set; }
        public DateTime AuditDate { get; set; }

        public long VesselId { get; set; } // Foreign key to Vessel entity

        public virtual Vessel Vessel { get; set; }

        public long AuditStatusId { get; set; } // Foreign key to Status entity

        public virtual AuditStatus AuditStatus { get; set; }

        public long AuditTypeId { get; set; } // Foreign key to Status entity

        public virtual AuditType AuditType { get; set; }

        public string MasterName { get; set; }

        public string PortAgentName { get; set; }

        public string PortAgentPhone { get; set; }

        public string PortAgentEmail { get; set; }

        public string EmbarkationPort { get; set; }

        public string DisembarkationPort { get; set; }

        public string Comment { get; set; }

        // Navigation Property: List of Attached Photos
        public virtual ICollection<AuditResponse> Responses { get; set; } = new List<AuditResponse>();
    }
}
