using Ellipse.Data.Entities;
using Ellipse.Shared.DTOs.Document;

namespace Ellipse.Core.Extensions
{
    public static class DocumentAccessExtensions
    {
        public static DocumentAccessDetails ToDetails(this DocumentAccess documentAccess)
        {
            return new DocumentAccessDetails
            {
                Id = documentAccess.Id,
                DocumentId = documentAccess.DocumentId,
                DateAccessed = documentAccess.DateAccessed,
                AccessedBy = documentAccess.AccessedBy
            };
        }

        public static DocumentAccess ToEntity(this DocumentAccessDetails documentAccessDetails)
        {
            return new DocumentAccess
            {
                Id = documentAccessDetails.Id,
                DocumentId = documentAccessDetails.DocumentId,
                DateAccessed = documentAccessDetails.DateAccessed,
                AccessedBy = documentAccessDetails.AccessedBy
            };
        }

        public static List<DocumentAccessDetails> ToListDetails(this List<DocumentAccess> documentAccesses)
        {
            return documentAccesses.Select(documentAccess => documentAccess.ToDetails()).ToList();
        }
    }
}