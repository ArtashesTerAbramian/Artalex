using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artalex.DAL.Models;

public class AuditQuestion : BaseEntity
{
    public string Name { get; set; }
    public long AuditChapterId { get; set; }
    public virtual AuditChapter AuditChapter { get; set; }
    public string Text { get; set; }
    public string Explanation { get; set; }
    public string ReferenceTo { get; set; }

    public virtual ICollection<AuditQuestionPotentialGround> PotentialGrounds { get; set; } = [];
    public virtual ICollection<AuditResponse> Responses { get; set; } = [];
    public virtual ICollection<AuditManagerResponse> AuditManagerResponses { get; set; } = [];
}
