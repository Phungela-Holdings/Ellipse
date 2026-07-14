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
        public string Status { get; set; } // nvarchar(MAX)

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime RequestedDate { get; set; }

        [Required]
        public long EllipseUserId { get; set; }

        [Required]
        public string EllipsePosition { get; set; } // nvarchar(MAX)

        [Required]
        public string MenuAccess { get; set; } // nvarchar(MAX)

        [Required]
        public string BusinessJustification { get; set; } // nvarchar(MAX)

        [Required]
        public string RequestType { get; set; } // nvarchar(MAX)

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