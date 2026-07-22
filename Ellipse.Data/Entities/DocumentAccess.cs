using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ellipse.Data.Entities
{
    public class DocumentAccess
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime DateAccessed { get; set; }

        public string AccessedBy { get; set; }

        [ForeignKey(nameof(Document))]
        public int DocumentId { get; set; }

        public Document Document { get; set; }
    }
}
