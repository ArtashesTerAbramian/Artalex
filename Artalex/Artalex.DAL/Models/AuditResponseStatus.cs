using System.ComponentModel.DataAnnotations;

namespace Artalex.DAL.Models
{
    public class AuditResponseStatus : BaseEntity
    {
        public string StatusName { get; set; }
        public bool SetByAuditor { get; set; } = true;
        public bool SetByManager { get; set; } = false;
    }
}
