using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artalex.DAL.Models
{
    public class AuditResponsePotentialGround : BaseEntity
    {
        public string Text { get; set; }
    }
}
