using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ellipse.Data.Entities
{
    public class DocumentAudit
    {
        [Key]
        public int Id { get; set; }
        public int DocumentId { get; set; }

        [ForeignKey(nameof(DocumentId))]
        public Document Document { get; set; }
        public DateTime DateCreated {get; set; } 
        public string AuditType { get; set; }
        public byte[] DocumentData { get; set; }
        public byte[] OldDocumentData { get; set; }
    }
}
