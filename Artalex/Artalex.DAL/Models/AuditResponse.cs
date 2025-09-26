namespace Artalex.DAL.Models
{
    public class AuditResponse : BaseEntity
    {
        public int AuditResponseStatusId { get; set; }
        public virtual AuditResponseStatus AuditResponseStatus { get; set; }
        public DateTime AuditResponseDate { get; set; }
        public int AuditResponseAssignedToId { get; set; }
        public virtual AuditResponseAssignedTo AuditResponseAssignedTo { get; set; }
        [Obsolete("ARTALEX-76: This property is obsolete. It was used to specify one of ten hardcoded potential grounds. Use 'AuditResponseQuestionPotentialGroundId' to specify question related potential ground.")]
        public int? AuditResponsePotentialGroundId { get; set; }
        public virtual AuditResponsePotentialGround AuditResponsePotentialGround { get; set; }
        public int? AuditResponseQuestionPotentialGroundId { get; set; }
        public virtual AuditQuestionPotentialGround AuditQuestionPotentialGround { get; set; }
        public string ResponseText { get; set; }

        public int AuditId { get; set; }
        public virtual Audit Audit { get; set; }
        public int AuditQuestionId { get; set; }
        public virtual AuditQuestion AuditQuestion { get; set; }

        // Navigation Property: List of Attached Photos
        public virtual ICollection<AuditResponsePhoto> Photos { get; set; } = new List<AuditResponsePhoto>();

    }
}
