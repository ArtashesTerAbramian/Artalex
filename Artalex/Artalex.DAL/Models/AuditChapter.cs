using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artalex.DAL.Models
{
    public class AuditChapter : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public int AuditTypeId { get; set; } 

        [ForeignKey(nameof(AuditTypeId))]
        public virtual AuditType AuditType { get; set; }



        // Navigation Property: List of Questions in this Chapter
        public virtual ICollection<AuditQuestion> Questions { get; set; }

        public AuditChapter()
        {
            Questions = new List<AuditQuestion>();
        }
    }
}
