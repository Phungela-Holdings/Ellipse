namespace Ellipse.Shared.DTOs.DocumentAccess
{
    public class DocumentAccessSearchCriteria
    {
        public int? DocumentId { get; set; }
        public string? AccessedBy { get; set; }
        public DateTime? DateAccessedFrom { get; set; }
        public DateTime? DateAccessedTo { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
