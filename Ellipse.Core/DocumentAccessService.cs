using System;

namespace Ellipse.Shared.DTOs.DocumentAccess
{
    public class DocumentAccessDetails
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string AccessedBy { get; set; } = string.Empty;
        public DateTime DateAccessed { get; set; }
    }

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