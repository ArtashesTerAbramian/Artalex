using System.ComponentModel.DataAnnotations;

namespace Artalex.DAL.Models
{
    public class AuditStatus : BaseEntity
    {
        public string StatusName { get; set; }
    }
}
