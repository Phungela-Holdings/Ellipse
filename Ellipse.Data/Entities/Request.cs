using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ellipse.Data.Entities
{
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Status { get; set; } 

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime RequestedDate { get; set; }

        public long EllipseUserId { get; set; }

        public string EllipsePosition { get; set; } 

        public string MenuAccess { get; set; } 

        public string BusinessJustification { get; set; } 

        public string RequestType { get; set; } 

        [StringLength(50)]
        public string Environment { get; set; }

        [StringLength(50)]
        public string UserAccessType { get; set; }

        [StringLength(50)]
        public string AdditionalUserAccess { get; set; }

        public long userId { get; set; }

        [StringLength(50)]
        public string UserType { get; set; }

        public List<Document> Documents { get; set; }

        public int? ContractId { get; set; }

        [ForeignKey(nameof(ContractId))]
        public Contractor? Contractor { get; set; }

        public string? EmployeeEmail { get; set; }


        [ForeignKey(nameof(EmployeeEmail))]
        public Employee? Employee { get; set; }

        public string? TemporaryPosition { get; set; }

        public int? TemporaryPostId { get; set; }

        public bool? MissingDocuments { get; set; }

        public bool? RequestClosed { get; set; }

        public int? HcOfficerApprovalId { get; set; }


        [ForeignKey(nameof(HcOfficerApprovalId))]
        public RequestApproverAction? HcOfficerApprover { get; set; }

        public int? LineManagerApprovalId { get; set; }

        public DateTime? TrainingCompletionDate { get; set; }

        public RequestApproverAction? LineManagerApprover { get; set; }

        public int? TrainingApproverId { get; set; }


        [ForeignKey(nameof(TrainingApproverId))]
        public RequestApproverAction? TrainingApprover { get; set; }

        public int? ICTManagerApprovalId { get; set; }


        [ForeignKey(nameof(ICTManagerApprovalId))]
        public RequestApproverAction? ICTManagerApprover { get; set; }

        public string? RejectionReason { get; set; }

        public string? ClosureReason { get; set; }
    }
}