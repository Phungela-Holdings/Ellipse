using Ellipse.Shared.DTOs.DocumentAudit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ellipse.Shared.Interfaces
{
    public interface IDocumentAuditService
    {
        // Create an audit record whenever a document is uploaded or modified
        DocumentAuditDetails CreateDocumentAudit(DocumentAuditDetails documentAuditDetails);

        // Get a single audit record
        DTOs.DocumentAudit.DocumentAuditDetails GetDocumentAuditById(int auditId);

        // Get all audits for a specific document
        List<DocumentAuditDetails> GetDocumentAuditsByDocument(int documentId);

        // Get every audit in the system (Admin)
        List<DocumentAuditDetails> GetAllDocumentAudits();

        // Delete an audit (optional - usually not allowed)
        bool DeleteDocumentAudit(int auditId);
    }
}