using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Artalex.DAL.Models
{
    public class AuditResponseAssignedTo : BaseEntity
    {
        public string Text { get; set; }
    }
}
