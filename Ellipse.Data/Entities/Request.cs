using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ellipse.Data.Entities
{
    public class Request
    {
        [Key]
        public int Id { get; set; }

        [Required]
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

        public int? HcAdminApprovalId { get; set; }

        [ForeignKey(nameof(HcAdminApprovalId))]
        public RequestApproval? HcAdminApproval { get; set; }

        public int? LineManagerApprovalId { get; set; }

        public DateTime? TrainingCompletionDate { get; set; }
        public RequestApproval? LineManagerApproval { get; set; }

        public int? TrainingApprovalId { get; set; }

        [ForeignKey(nameof(TrainingApprovalId))]
        public RequestApproval? TrainingApproval { get; set; }

        public int? ICTManagerApprovalId { get; set; }

        [ForeignKey(nameof(ICTManagerApprovalId))]

        public RequestApproval? ICTManagerApproval { get; set; }

        public string? Rejection { get; set; }
    }
}