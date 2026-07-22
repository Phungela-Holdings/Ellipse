using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ellipse.Data.Entities
{
    public class DocumentAudit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int DocumentId { get; set; }


        [ForeignKey(nameof(DocumentId))]
        public Document Document { get; set; }

        public DateTime DateCreated {get; set; } 

        public string AuditType { get; set; }
    }
}
