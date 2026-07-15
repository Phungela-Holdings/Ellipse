using System.ComponentModel.DataAnnotations.Schema;

namespace Ellipse.Data.Entities
{
    public class DocumentAccess
    {
        public int Id { get; set; }

        public int DocumentId { get; set; }

        [ForeignKey(nameof(DocumentId))]

        public Document Document { get; set; }

        public DateTime DateAccessed { get; set; }

        public string AccessedBy { get; set; }
    }
}
