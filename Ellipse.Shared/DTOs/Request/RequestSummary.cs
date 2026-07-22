namespace Ellipse.Shared.DTOs.Request
{
    public class RequestSummary
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public string RequestType { get; set; }

        public string Environment { get; set; }

        public string UserAccessType { get; set; }

        public string AdditionalUserAccess { get; set; }
    }
}
