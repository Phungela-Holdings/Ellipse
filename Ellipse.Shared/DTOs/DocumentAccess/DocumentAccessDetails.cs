namespace Ellipse.Shared.DTOs.DocumentAccess
{
    public class DocumentAccessDetails
    {
        public int Id { get; set; }

        public int DocumentId { get; set; }

        public string AccessedBy { get; set; }

        public DateTime DateAccessed { get; set; }
    }
}
