using Ellipse.Shared.DTOs.DocumentAudit;

namespace Ellipse.Shared.Interfaces
{
    public interface IDocumentAuditService
    {
        Task<bool> CreateDocumentAudit(DocumentAuditDetails documentAuditDetails);

        Task<List<DocumentAuditDetails>> GetDocumentAuditsByDocumentAsync(int documentId);

        Task<List<DocumentAuditDetails>> GetAllDocumentAuditsAsync();
    }
}