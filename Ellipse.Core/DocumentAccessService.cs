using Ellipse.Data;
using Ellipse.Shared.Interfaces;
using Ellipse.Core.Extensions;
using Ellipse.Shared.DTOs.DocumentAccess;

namespace Ellipse.Core
{
    public class DocumentAccessService : IDocumentAccessService
    {
        private readonly EllipseDbContext _context;

        public DocumentAccessService(EllipseDbContext context)
        {
            _context = context;
        }

        public async Task<List<DocumentAccessDetails>> GetDocumentAccessAsync(int documentId)
        {
            return _context.DocumentAccesses
            .Where(x => x.DocumentId == documentId)
            .ToList().ToDetailsList();
        }
    }
}