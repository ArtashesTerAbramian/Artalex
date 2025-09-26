using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artalex.DAL.Models
{
    public class AuditChapter : BaseEntity
    {
        public string Name { get; set; }
        public long AuditTypeId { get; set; } 

        public virtual AuditType AuditType { get; set; }


        public virtual ICollection<AuditQuestion> Questions { get; set; }

        public AuditChapter()
        {
            Questions = new List<AuditQuestion>();
        }
    }
}
