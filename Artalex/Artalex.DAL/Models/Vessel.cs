using System.ComponentModel.DataAnnotations;

namespace Artalex.DAL.Models
{
    public class Vessel : BaseEntity
    {
        public string Name { get; set; }
        public string IMO { get; set; }
        public DateTime? LastAuditDate { get; set; }
        public DateTime? NextAuditDate { get; set; }
        public string? LastAuditorName { get; set; }
        public string Email { get; set; }
        
        public virtual ICollection<VesselFile> Files { get; set; } = new List<VesselFile>();
    }
}
