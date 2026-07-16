using Ellipse.Shared.DTOs.DocumentAudit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ellipse.Shared.Interfaces
{
    public interface IDocumentAuditService
    {
        bool CreateDocumentAudit(DocumentAuditDetails documentAuditDetails);

        DocumentAuditDetails GetDocumentAuditById(int id);

        List<DocumentAuditDetails> GetDocumentAuditsByDocument(int documentId);

        List<DocumentAuditDetails> GetAllDocumentAudits();

        bool DeleteDocumentAudit(int id);
    }
}