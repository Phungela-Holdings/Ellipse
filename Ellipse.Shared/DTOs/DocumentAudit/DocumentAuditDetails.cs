using System;

namespace Ellipse.Shared.DTOs.DocumentAudit
{
    public class DocumentAuditDetails
    {
        public int Id { get; set; }

        public int DocumentId { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuditType { get; set; } = string.Empty;

        public byte[] DocumentData { get; set; } = Array.Empty<byte>();

        public byte[]? OldDocumentData { get; set; }
    }
}