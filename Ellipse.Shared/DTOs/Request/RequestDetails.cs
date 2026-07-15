using Ellipse.Shared.DTOs.Document;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ellipse.Shared.DTOs.Request
{
    public class RequestDetails
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime RequestedDate { get; set; }

        [Required]
        public long EllipseUserId { get; set; }

        [Required]
        public string EllipsePosition { get; set; } 

        [Required]
        public string MenuAccess { get; set; } 

        [Required]
        public string BusinessJustification { get; set; } 

        [Required]
        public string RequestType { get; set; } 

        [Required]
        [StringLength(50)]
        public string Environment { get; set; }

        [Required]
        [StringLength(50)]
        public string UserAccessType { get; set; }

        [Required]
        [StringLength(50)]
        public string AdditionalUserAccess { get; set; }

        [Required]
        public long userId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserType { get; set; }

        public List<DocumentDetails> Documents { get; set; }

        public int? ContractId { get; set; }

        public ContractorSummary? Contractor { get; set; }

        public string? EmployeeEmail { get; set; }

        [ForeignKey(nameof(EmployeeEmail))]
        public Employee? E { get; set; }

        public string? TemporaryPosition { get; set; }

        public int? TemporaryPostId { get; set; }

        public bool? MissingDocuments { get; set; }

        public bool? LineManagerApproved { get; set; }

        public bool? TrainingVerified { get; set; }

        public bool? ICTManagerApproved { get; set; }

        public bool? HCSystemsAdminApproved { get; set; }

        public DateTime? TrainingCompletionDate { get; set; }

        public bool? RequestClosed { get; set; }

        // Foreign keys will be added after Approval table is created
        public int? HcAdminApprovalId { get; set; }

        public int? LineManagerApprovalId { get; set; }

        public int? TrainingApprovalId { get; set; }

        public int? ICTManagerApprovalId { get; set; }
    }
}
