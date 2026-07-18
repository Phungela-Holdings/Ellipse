using Microsoft.EntityFrameworkCore;
using Ellipse.Core.Extensions;
using Ellipse.Data;
using Ellipse.Data.Entities;
using Ellipse.Shared.DTOs;
using Ellipse.Shared.Interfaces;

namespace Ellipse.Core
{
    public class DocumentAccessService : IDocumentAccessService
    {
        private readonly EllipseDbContext _context;

        public DocumentAccessService(EllipseDbContext context)
        {
            _context = context;
        }

        public async Task<DocumentAccessDetails> CreateDocumentAccessAsync(DocumentAccessDetails documentAccessDetails)
        {
            var entity = documentAccessDetails.ToEntity();

            entity.DateAccessed = entity.DateAccessed == default
                ? DateTime.UtcNow
                : entity.DateAccessed;

            _context.Set<DocumentAccess>().Add(entity);

            await _context.SaveChangesAsync();

            return entity.ToDetails();
        }

        public async Task<List<DocumentAccessDetails>> GetDocumentAccessAsync(int documentId)
        {
            var documentAccesses = await _context.Set<DocumentAccess>()
                .Where(documentAccess => documentAccess.DocumentId == documentId)
                .ToListAsync();

            return documentAccesses.ToListDetails();
        }

        public async Task<List<DocumentAccessDetails>> SearchDocumentAccessAsync(DocumentAccessSearchCriteria searchCriteria)
        {
            var query = _context.Set<DocumentAccess>().AsQueryable();

            query = searchCriteria.DocumentId.HasValue
                ? query.Where(documentAccess => documentAccess.DocumentId == searchCriteria.DocumentId.Value)
                : query;

            query = string.IsNullOrWhiteSpace(searchCriteria.AccessedBy)
                ? query
                : query.Where(documentAccess => documentAccess.AccessedBy == searchCriteria.AccessedBy);

            query = searchCriteria.DateAccessedFrom.HasValue
                ? query.Where(documentAccess => documentAccess.DateAccessed >= searchCriteria.DateAccessedFrom.Value)
                : query;

            query = searchCriteria.DateAccessedTo.HasValue
                ? query.Where(documentAccess => documentAccess.DateAccessed <= searchCriteria.DateAccessedTo.Value)
                : query;

            var pageNumber = searchCriteria.PageNumber <= 0 ? 1 : searchCriteria.PageNumber;

            var pageSize = searchCriteria.PageSize <= 0 ? 10 : searchCriteria.PageSize;

            var documentAccesses = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return documentAccesses.ToListDetails();
        }
    }
}
