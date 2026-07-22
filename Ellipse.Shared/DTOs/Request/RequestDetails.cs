using Ellipse.Shared.DTOs.Contractor;
using Ellipse.Shared.DTOs.Document;
using Ellipse.Shared.DTOs.Employee;

namespace Ellipse.Shared.DTOs.Request
{
    public class RequestDetails
    {
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

        public string Environment { get; set; }

       public string UserAccessType { get; set; }

        public string AdditionalUserAccess { get; set; }

        public long userId { get; set; }

        public string UserType { get; set; }

        public List<DocumentDetails> Documents { get; set; }

        public ContractorSummary? Contractor { get; set; }

        public EmployeeSummary? Employee { get; set; }

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
