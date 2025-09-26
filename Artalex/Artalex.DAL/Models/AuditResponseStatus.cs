using System.ComponentModel.DataAnnotations;

namespace Artalex.DAL.Models
{
    public class AuditResponseStatus : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string StatusName { get; set; }

        // Boolean field with a default value
        public bool SetByAuditor { get; set; } = true;

        // Boolean field with a default value
        public bool SetByManager { get; set; } = false;
    }
}
