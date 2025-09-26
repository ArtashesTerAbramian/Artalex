using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artalex.DAL.Models
{
    public class AuditType : BaseEntity
    {
        public string Name { get; set; }
        
        public virtual ICollection<AuditChapter> Chapters { get; set; }
    }
}
