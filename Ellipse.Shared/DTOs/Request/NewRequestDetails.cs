using System;
using System.Collections.Generic;
using System.Text;

namespace Ellipse.Shared.DTOs.Request
{
    public class NewRequestDetails
    {
        public long EllipseUserId { get; set; }
        public string EllipsePosition { get; set; }
        public string MenuAccess { get; set; }
        public string BusinessJustification { get; set; }
        public string RequestType { get; set; }
        public string Environment { get; set; }
        public string UserAccessType { get; set; }
        public string AdditionalUserAccess { get; set; }
        public long UserId { get; set; }
        public string UserType { get; set; }
        public string? TemporaryPosition { get; set; }
        public int? TemporaryPostId { get; set; }
    }
}