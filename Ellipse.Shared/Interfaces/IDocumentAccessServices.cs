using Ellipse.Shared.DTOs.DocumentAccess;

namespace Ellipse.Shared.Interfaces
{
    public interface IDocumentAccessService
    {
        /// <summary>
        /// Creates a new document access record with the provided details.
        /// </summary>
        /// <param name="documentAccessDetails">The document access details to create.</param>
        /// <returns>The created DocumentAccessDetails object.</returns>
        Task<DocumentAccessDetails> CreateDocumentAccessAsync(DocumentAccessDetails documentAccessDetails);

        /// <summary>
        /// Retrieves all document access records for a specific document.
        /// </summary>
        /// <param name="documentId">The ID of the document.</param>
        /// <returns>A list of DocumentAccessDetails for the specified document.</returns>
        Task<List<DocumentAccessDetails>> GetDocumentAccessAsync(int documentId);

        /// <summary>
        /// Searches document access records based on criteria.
        /// </summary>
        /// <param name="searchCriteria">The search criteria.</param>
        /// <returns>A list of matching DocumentAccessDetails.</returns>
        Task<List<DocumentAccessDetails>> SearchDocumentAccessAsync(DocumentAccessSearchCriteria searchCriteria);
    }
}
