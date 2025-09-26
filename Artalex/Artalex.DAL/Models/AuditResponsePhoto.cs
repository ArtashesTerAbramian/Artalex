using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artalex.DAL.Models
{
    public class AuditResponsePhoto : BaseEntity
    {
        public string FileName { get; set; } // Stored file name
        public string FilePath { get; set; } // Path where the file is stored
        public long AuditResponseId { get; set; }
        public virtual AuditResponse AuditResponse { get; set; }
    }
}
