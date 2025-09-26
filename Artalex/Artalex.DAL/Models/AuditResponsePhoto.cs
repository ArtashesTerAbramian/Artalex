using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artalex.DAL.Models
{
    public class AuditResponsePhoto : BaseEntity
    {
        [Required]
        public string FileName { get; set; } // Stored file name

        [Required]
        public string FilePath { get; set; } // Path where the file is stored

        // Foreign Key to AuditResponse
        [Required]
        public int AuditResponseId { get; set; }
        [ForeignKey(nameof(AuditResponseId))]
        public virtual AuditResponse AuditResponse { get; set; }
    }
}
