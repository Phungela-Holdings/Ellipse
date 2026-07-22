using System;

namespace Ellipse.Shared.DTOs
{
    public class RequestApproverActionDetails
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public long PostId { get; set; }

        public long ServiceNumber { get; set; }

        public DateTime ApproverDate { get; set; }

        public int RequestId { get; set; }

        public string ApproverType { get; set; } = string.Empty;
        public string ActionType { get; set; }
    }
}