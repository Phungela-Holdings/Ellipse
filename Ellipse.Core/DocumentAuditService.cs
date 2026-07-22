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

        public async Task<bool> CreateDocumentAudit(DocumentAuditDetails documentAuditDetails)
        {
            var document = await _context.Documents.FindAsync(documentAuditDetails.DocumentId);

            if (document == null)
            {
                return false;
            }

            var documentAudit = documentAuditDetails.ToEntity();
            documentAudit.Document = document;

            await _context.DocumentAudits.AddAsync(documentAudit);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<DocumentAuditDetails?> GetDocumentAuditById(int id)
        {
            var audit = await _context.DocumentAudits.FindAsync(id);

            return audit?.ToDetails();
        }

        public async Task<List<DocumentAuditDetails>> GetDocumentAuditsByDocument(int documentId)
        {
            return await _context.DocumentAudits
                .Where(x => x.DocumentId == documentId)
                .Select(x => x.ToDetails())
                .ToListAsync();
        }

        public async Task<List<DocumentAuditDetails>> GetAllDocumentAudits()
        {
            return await _context.DocumentAudits
                .Select(x => x.ToDetails())
                .ToListAsync();
        }
    }
}