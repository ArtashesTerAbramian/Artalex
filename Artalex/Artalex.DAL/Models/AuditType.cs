using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artalex.DAL.Models
{
    public class AuditType : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        // Navigation Property: List of Chapters in this Type
        public virtual ICollection<AuditChapter> Chapters { get; set; }
    }
}
