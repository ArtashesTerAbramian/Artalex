using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artalex.DAL.Models
{
    public class UserFile : BaseEntity
    {
        [Required]
        public string FileName { get; set; } // Stored file name

        [Required]
        public string FilePath { get; set; } // Path where the file is stored

        // Foreign Key to AuditResponse
        [Required]
        public long UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
