using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artalex.DAL.Models;

public class AuditQuestionPotentialGround : BaseEntity
{
    [Required]
    [MaxLength(250)]
    [Column(TypeName = "text")]
    public string Text { get; set; }

    public int AuditQuestionId { get; set; }
    [ForeignKey(nameof(AuditQuestionId))]
    public virtual AuditQuestion AuditQuestion { get; set; }
}
