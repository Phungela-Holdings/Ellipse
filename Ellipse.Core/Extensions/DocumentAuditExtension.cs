using Ellipse.Data.Entities;
using Ellipse.Shared.DTOs.DocumentAudit;

namespace Ellipse.Core.Extensions
{
    public static class DocumentAuditExtensions
    {
        public static DocumentAuditDetails ToDetails(this DocumentAudit documentAudit)
        {
            return new DocumentAuditDetails
            {
                Id = documentAudit.Id,
                DocumentId = documentAudit.DocumentId,
                DateCreated = documentAudit.DateCreated,
                AuditType = documentAudit.AuditType
            };
        }

        public static DocumentAudit ToEntity(this DocumentAuditDetails documentAuditDetails)
        {
            return new DocumentAudit
            {
                Id = documentAuditDetails.Id,
                DateCreated = documentAuditDetails.DateCreated,
                AuditType = documentAuditDetails.AuditType,
            };
        }

        public static List<DocumentAuditDetails> ToDetailsList(this List<DocumentAudit> documentAudits)
        {
            return documentAudits.Select(o => o.ToDetails()).ToList();
        }
    }
}