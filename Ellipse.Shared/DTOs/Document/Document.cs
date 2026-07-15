using System;
using System.Collections.Generic;
using System.Text;

namespace Ellipse.Shared.DTOs.Document
{
    public class Document
    {
        public int Id { get; set; }
        public byte[] Data { get; set; } = Array.Empty<byte>();
        public DateTime DateUploaded { get; set; }
        public DateTime? DateModified { get; set; }
        public string DocumentType { get; set; } = string.Empty;
        public int RequestId { get; set; }
        public bool Active { get; set; }
        public bool Archived { get; set; }
        public DateTime? ArchivedDate { get; set; }


    }
}
