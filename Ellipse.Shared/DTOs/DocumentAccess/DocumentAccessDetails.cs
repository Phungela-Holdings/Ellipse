namespace Ellipse.Shared.DTOs.DocumentAccess
{
    public class DocumentAccessDetails
    {
        public int Id { get; set; }
        public int DocumentId { get; set; }
        public string AccessedBy { get; set; } = string.Empty;
        public DateTime DateAccessed { get; set; }
    }
}
