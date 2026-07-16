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
            await _context.DocumentAudits.AddAsync(documentAuditDetails.ToEntity());
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<DocumentAuditDetails?> GetDocumentAuditById(int id)
        {
            return await _context.DocumentAudits
                .Where(x => x.Id == id)
                .Select(x => x.ToDetails())
                .FirstOrDefaultAsync();
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

        public async Task<bool> DeleteDocumentAudit(int id)
        {
            var documentAudit = await _context.DocumentAudits.FindAsync(id);

            _context.DocumentAudits.Remove(documentAudit);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}