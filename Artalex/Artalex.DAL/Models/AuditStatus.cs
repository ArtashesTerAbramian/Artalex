using System.ComponentModel.DataAnnotations;

namespace Artalex.DAL.Models
{
    public class AuditStatus : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string StatusName { get; set; }
    }
}
