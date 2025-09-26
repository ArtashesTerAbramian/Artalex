using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artalex.DAL.Models
{
    public class AuditResponseAssignedTo : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Text { get; set; }
    }
}
