using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artalex.DAL.Models;

public class AuditQuestionPotentialGround : BaseEntity
{
    public string Text { get; set; }
    public long AuditQuestionId { get; set; }
    public virtual AuditQuestion AuditQuestion { get; set; }
}
