namespace Ellipse.Shared.DTOs.Request
{
    public class RequestDetails
    {
        public int Id { get; set; }

        public string Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime RequestedDate { get; set; }
    }
}
