using System;

namespace Ellipse.Shared.DTOs
{
    public class RequestApprovalDetails
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public long PostId { get; set; }

        public long ServiceNumber { get; set; }

        public DateTime ApprovalDate { get; set; }

        public int RequestId { get; set; }

        public string ApprovalType { get; set; } = string.Empty;
    }
}