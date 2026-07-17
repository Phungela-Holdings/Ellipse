using Ellipse.Shared.DTOs.Document;

namespace Ellipse.Shared.Interfaces
{
    public interface IDocumentService
    {
        Task<DocumentDetails> CreateDocument(DocumentDetails documentDetails);

        Task<DocumentDetails> GetDocumentById(int id);

        Task<List<DocumentDetails>> GetRequestDocument(int requestId);

        Task<DocumentDetails> UpdateDocument(DocumentDetails documentDetails);

        Task<bool> DeleteDocument(int id);

        Task<bool> ArchiveDocument(int id);

        Task<byte[]> DownloadDocument(int id);
    }
}