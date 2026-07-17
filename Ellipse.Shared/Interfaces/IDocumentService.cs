using Ellipse.Shared.DTOs;
using Ellipse.Shared.DTOs.DocumentDetails;

namespace Ellipse.Shared.Interfaces
{
    public interface IDocumentService
    {
        Task<DocumentDetails> CreateDocument(DocumentDetails documentDetails);

        Task<DocumentDetails> GetDocumentById(int documentId);

        Task<List<DocumentDetails>> GetRequestDocuments(int requestId);

        Task<DocumentDetails> UpdateDocument(DocumentDetails documentDetails);

        Task<bool> DeleteDocument(int documentId);

        Task<bool> ArchiveDocument(int documentId);

        Task<byte[]> DownloadDocument(int documentId);
    }
}
