using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ellipse.Data.Entities
{
    public class Request
    {
        [Required]
        [StringLength(50)]
        public string UserType { get; set; }

        public List<Document> Documents { get; set; } = new();

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

        public int? HcAdminApprovalId { get; set; }

        public int? LineManagerApprovalId { get; set; }

        public int? TrainingApprovalId { get; set; }

        public int? ICTManagerApprovalId { get; set; }
    }
}