using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artalex.DAL.Models;

public class AuditQuestion : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public int AuditChapterId { get; set; }

    [ForeignKey(nameof(AuditChapterId))]
    public virtual AuditChapter AuditChapter { get; set; }
    
    [Column(TypeName = "text")]
    public string Text { get; set; }
    
    [Column(TypeName = "text")]
    public string Explanation { get; set; }
    public string ReferenceTo { get; set; }

    public virtual ICollection<AuditQuestionPotentialGround> PotentialGrounds { get; set; } = [];
    public virtual ICollection<AuditResponse> Responses { get; set; } = [];
    public virtual ICollection<AuditManagerResponse> AuditManagerResponses { get; set; } = [];
}
