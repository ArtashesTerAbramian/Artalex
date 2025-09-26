using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artalex.DAL.Models
{
    public class AuditResponsePotentialGround : BaseEntity
    {
        [Required]
        [MaxLength(100)]

        [Column(TypeName = "text")]
        public string Text { get; set; }
    }
}
