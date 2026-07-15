using System.ComponentModel.DataAnnotations.Schema;

namespace Ellipse.Data.Entities
{
    public class DocumentAccess
    {
        public int Id { get; set; }

        public DateTime DateAccessed { get; set; }

        public string AccessedBy { get; set; }

        // Foreign key
        [ForeignKey(nameof(Document))]
        public int DocumentId { get; set; }

        // Navigation property
        public Document Document { get; set; }
    }
}
