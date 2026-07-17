using Microsoft.EntityFrameworkCore;
using Ellipse.Core.Extensions;
using Ellipse.Data;
using Ellipse.Shared.Interfaces;
using Ellipse.Shared.DTOs.DocumentDetails;

namespace Ellipse.Core
{
    public class DocumentService : IDocumentService
    {
        private readonly EllipseDbContext _context;

        public DocumentService(EllipseDbContext context)
        {
            _context = context;
        }

        public async Task<DocumentDetails> CreateDocument(DocumentDetails documentDetails)
        {
            var document = documentDetails.ToEntity();


            _context.Documents.Add(document);

            await _context.SaveChangesAsync();

            return document.ToDetails();
        }

        public async Task<DocumentDetails> GetDocumentById(int documentId)
        {
            var document = await _context.Documents.FindAsync(documentId)
                ?? throw new KeyNotFoundException(
                    $"Document with ID {documentId} not found");

            return document.ToDetails();
        }

        public async Task<List<DocumentDetails>> GetRequestDocuments(int requestId)
        {
            var documents = await _context.Documents
                .Where(d => d.RequestId == requestId)
                .ToListAsync();

            return documents.ToListDetails();
        }

        public async Task<DocumentDetails> UpdateDocument(
            DocumentDetails documentDetails)
        {
            var document = await _context.Documents.FindAsync(documentDetails.Id)
                ?? throw new KeyNotFoundException(
                    $"Document with ID {documentDetails.Id} not found");

            document.Data = documentDetails.Data;
            document.DateModified = DateTime.UtcNow;
            document.DocumentType = documentDetails.DocumentType;


            await _context.SaveChangesAsync();

            return document.ToDetails();
        }

        public async Task<bool> DeleteDocument(int documentId)
        {
            var document = await _context.Documents.FindAsync(documentId);

            if (document == null)
            {
                return false;
            }

            document.Active = false;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ArchiveDocument(int documentId)
        {
            var entity = await _context.Documents.FindAsync(documentId);

            if (entity == null)
            {
                return false;
            }

            entity.Archived = true;
            entity.ArchivedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<byte[]> DownloadDocument(int documentId)
        {
            var entity = await _context.Documents.FindAsync(documentId)
                ?? throw new KeyNotFoundException(
                    $"Document with ID {documentId} not found");

            return entity.Data ?? Array.Empty<byte>();
        }
    }
}