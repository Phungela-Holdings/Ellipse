using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ellipse.Data.Entities
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateUploaded { get; set; }

        public DateTime? DateModified { get; set; }

        public string DocumentType { get; set; } = string.Empty;

        public int RequestId { get; set; }

        [ForeignKey(nameof(RequestId))]
        public Request Request { get; set; } = null!;

        public bool Active { get; set; }

        public bool Archived { get; set; }

        public DateTime? ArchivedDate { get; set; }
    }
}
