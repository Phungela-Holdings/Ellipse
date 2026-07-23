using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ellipse.Data.Entities
{
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public byte[] Data { get; set; }

        public DateTime DateUploaded { get; set; }

        public DateTime? DateModified { get; set; }

        public string DocumentType { get; set; }

        public int RequestId { get; set; }

        [ForeignKey(nameof(RequestId))]
        public Request Request { get; set; }

        public bool IsActive { get; set; }

        public bool Archived { get; set; }

        public DateTime? ArchivedDate { get; set; }






    }
}
