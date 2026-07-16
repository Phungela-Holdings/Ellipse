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
            var entity = documentDetails.ToEntity();

            entity.DateUploaded = documentDetails.DateUploaded == default
                ? DateTime.UtcNow
                : documentDetails.DateUploaded;

            _context.Documents.Add(entity);

            await _context.SaveChangesAsync();

            return entity.ToDetails();
        }

        public async Task<DocumentDetails> GetDocumentById(int documentId)
        {
            var entity = await _context.Documents.FindAsync(documentId)
                ?? throw new KeyNotFoundException(
                    $"Document with ID {documentId} not found");

            return entity.ToDetails();
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
            var existing = await _context.Documents.FindAsync(documentDetails.Id)
                ?? throw new KeyNotFoundException(
                    $"Document with ID {documentDetails.Id} not found");

            existing.Data = documentDetails.Data;
            existing.DateModified = DateTime.UtcNow;
            existing.DocumentType = documentDetails.DocumentType;
            existing.Active = documentDetails.Active;
            existing.Archived = documentDetails.Archived;
            existing.ArchivedDate = documentDetails.ArchivedDate;

            await _context.SaveChangesAsync();

            return existing.ToDetails();
        }

        public async Task<bool> DeleteDocument(int documentId)
        {
            var entity = await _context.Documents.FindAsync(documentId);

            if (entity == null)
            {
                return false;
            }

            _context.Documents.Remove(entity);

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