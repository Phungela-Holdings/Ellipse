using Ellipse.Shared.DTOs.DocumentAccess;

namespace Ellipse.Shared.Interfaces
{
    public interface IDocumentAccessService
    {

        /// <summary>
        /// Retrieves all document access records for a specific document.
        /// </summary>
        /// <param name="documentId">The ID of the document.</param>
        /// <returns>A list of DocumentAccessDetails for the specified document.</returns>
        Task<List<DocumentAccessDetails>> GetDocumentAccessAsync(int documentId);
    }
}
