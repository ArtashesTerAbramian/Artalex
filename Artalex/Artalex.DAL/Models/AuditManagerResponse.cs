﻿namespace Artalex.DAL.Models
{
    public class AuditManagerResponse : BaseEntity
    {
        public DateTime AuditResponseDate { get; set; }
        public string ResponseText { get; set; }
        public long ManagerId { get; set; }
        public virtual User Manager { get; set; }
        public int AuditId { get; set; }
        public virtual Audit Audit { get; set; }
        public int AuditQuestionId { get; set; }
        public virtual AuditQuestion AuditQuestion { get; set; }
    }
}
