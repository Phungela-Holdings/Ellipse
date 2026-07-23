namespace Ellipse.Shared.DTOs.Document
{
    public class DocumentDetails
    {
        public int Id { get; set; }

    public byte[] Data { get; set; } 

        public DateTime DateUploaded { get; set; }

        public DateTime? DateModified { get; set; }

    public string DocumentType { get; set; } 

        public int RequestId { get; set; }

        public bool Active { get; set; }

        public bool Archived { get; set; }

        public DateTime? ArchivedDate { get; set; }


    }
}
