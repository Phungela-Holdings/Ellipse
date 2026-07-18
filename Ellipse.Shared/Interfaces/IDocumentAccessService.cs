using System.Collections.Generic;
using System.Threading.Tasks;
using Ellipse.Shared.DTOs;

namespace Ellipse.Shared.Interfaces
{
    public interface IDocumentAccessService
    {
        Task<DocumentAccessDetails> CreateDocumentAccessAsync(DocumentAccessDetails documentAccessDetails);

        Task<List<DocumentAccessDetails>> GetDocumentAccessAsync(int documentId);

        Task<List<DocumentAccessDetails>> SearchDocumentAccessAsync(DocumentAccessSearchCriteria searchCriteria);
    }
}