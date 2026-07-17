using Ellipse.Shared.DTOs.DocumentAudit;

namespace Ellipse.Shared.Interfaces
{
    public interface IDocumentAuditService
    {
        Task<bool> CreateDocumentAudit(DocumentAuditDetails documentAuditDetails);

        Task<DocumentAuditDetails?> GetDocumentAuditById(int id);

        Task<List<DocumentAuditDetails>> GetDocumentAuditsByDocument(int documentId);

        Task<List<DocumentAuditDetails>> GetAllDocumentAudits();
    }
}