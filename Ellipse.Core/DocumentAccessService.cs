using Ellipse.Data;
using Ellipse.Shared.Interfaces;
using Ellipse.Core.Extensions;
using System;

namespace Ellipse.Shared.DTOs.DocumentAccess
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
            .ToList().ToListDetails();
        }

        public async Task<DocumentAccessDetails> CreateDocumentAccessAsync(DocumentAccessDetails documentAccessDetails)
        {
            var documentAccess = documentAccessDetails.ToEntity();
            documentAccess.DateAccessed = DateTime.Now;

            _context.DocumentAccesses.Add(documentAccess);
            await _context.SaveChangesAsync();

            return documentAccess.ToDetails();
        }

        public async Task<List<DocumentAccessDetails>> SearchDocumentAccessAsync(DocumentAccessSearchCriteria searchCriteria)
        {
            var query = _context.DocumentAccesses.AsQueryable();

            if (searchCriteria.DocumentId.HasValue)
            {
                query = query.Where(x => x.DocumentId == searchCriteria.DocumentId.Value);
            }

            if (!string.IsNullOrEmpty(searchCriteria.AccessedBy))
            {
                query = query.Where(x => x.AccessedBy.Contains(searchCriteria.AccessedBy));
            }

            if (searchCriteria.DateAccessedFrom.HasValue)
            {
                query = query.Where(x => x.DateAccessed >= searchCriteria.DateAccessedFrom.Value);
            }

            if (searchCriteria.DateAccessedTo.HasValue)
            {
                query = query.Where(x => x.DateAccessed <= searchCriteria.DateAccessedTo.Value);
            }

            if (searchCriteria.PageNumber > 0 && searchCriteria.PageSize > 0)
            {
                query = query
                .Skip((searchCriteria.PageNumber - 1) * searchCriteria.PageSize)
                .Take(searchCriteria.PageSize);
            }

            return query.ToList().ToListDetails();
        }
    }
}
