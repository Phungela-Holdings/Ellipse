using System;
using System.Collections.Generic;
using System.Text;

namespace Ellipse.Shared.DTOs.DocumentAudit
{
    namespace Ellipse.Shared.DTOs
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
}