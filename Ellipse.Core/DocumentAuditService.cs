using Ellipse.Core.Extensions;
using Ellipse.Data;
using Ellipse.Shared.DTOs.DocumentAudit;
using Ellipse.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ellipse.Core
{
    public class DocumentAuditService : IDocumentAuditService
    {
        private readonly EllipseDbContext _context;

        public DocumentAuditService(EllipseDbContext context)
        {
            _context = context;
        }

        public async Task<List<DocumentAuditDetails>> GetDocumentAuditsByDocumentAsync(int documentId)
        {
            var audits = await _context.DocumentAudits.Include(o => o.Document).Where(o => o.DocumentId == documentId).ToListAsync();

            return audits.ToDetailsList();
        }

        public async Task<List<DocumentAuditDetails>> GetAllDocumentAuditsAsync()
        {
            var audits = await _context.DocumentAudits.Include(o => o.Document).ToListAsync();

            return audits.ToDetailsList();
        }

        public async Task<bool> CreateDocumentAudit(DocumentAuditDetails documentAuditDetails)
        {
            var document = await _context.Documents.FindAsync(documentAuditDetails.DocumentId);

            if(document == null)
            {
                return false;
            }

            var documentAudit = documentAuditDetails.ToEntity();
            documentAudit.Document = document;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}