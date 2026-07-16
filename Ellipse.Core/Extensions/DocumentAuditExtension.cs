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
                AuditType = documentAudit.AuditType,
                DocumentData = documentAudit.DocumentData,
                OldDocumentData = documentAudit.OldDocumentData
            };
        }

        public static DocumentAudit ToEntity(this DocumentAuditDetails documentAuditDetails)
        {
            return new DocumentAudit
            {
                Id = documentAuditDetails.Id,
                DocumentId = documentAuditDetails.DocumentId,
                DateCreated = documentAuditDetails.DateCreated,
                AuditType = documentAuditDetails.AuditType,
                DocumentData = documentAuditDetails.DocumentData,
                OldDocumentData = documentAuditDetails.OldDocumentData
            };
        }
    }
}