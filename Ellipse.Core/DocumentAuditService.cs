using Ellipse.Shared.DTOs.DocumentAudit;
using Ellipse.Shared.Interfaces;

namespace Ellipse.Core
{
    public class DocumentAuditService : IDocumentAuditService
    {
        public bool CreateDocumentAudit(DocumentAuditDetails documentAuditDetails)
        {
            throw new NotImplementedException();
        }

        public DocumentAuditDetails GetDocumentAuditById(int id)
        {
            throw new NotImplementedException();
        }

        public List<DocumentAuditDetails> GetDocumentAuditsByDocument(int documentId)
        {
            throw new NotImplementedException();
        }

        public List<DocumentAuditDetails> GetAllDocumentAudits()
        {
            throw new NotImplementedException();
        }

        public bool DeleteDocumentAudit(int id)
        {
            throw new NotImplementedException();
        }
    }
}