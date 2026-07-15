using Ellipse.Data.Entities;
using DocumentDetails = Ellipse.Shared.DTOs.Document.Document;

namespace Ellipse.Core.Extensions
{
    public static class DocumentExtension
    {
        public static DocumentDetails ToDetails(this Document document)
        {
            return new DocumentDetails
            {
                Id = document.Id,
                Data = document.Data,
                DateUploaded = document.DateUplouded,
                DateModified = document.DateModified,
                DocumentType = document.DocumentType,
                RequestId = document.RequestId,
                Active = document.IsActive,
                Archived = document.Archived,
                ArchivedDate = document.ArchivedDate
            };
        }

        public static Document ToEntity(this DocumentDetails documentDetails)
        {
            return new Document
            {
                Id = documentDetails.Id,
                Data = documentDetails.Data,
                DateUplouded = documentDetails.DateUploaded,
                DateModified = documentDetails.DateModified,
                DocumentType = documentDetails.DocumentType,
                RequestId = documentDetails.RequestId,
                IsActive = documentDetails.Active,
                Archived = documentDetails.Archived,
                ArchivedDate = documentDetails.ArchivedDate
            };
        }

        public static List<DocumentDetails> ToListDetails(this List<Document> documents)
        {
            return documents.Select(document => document.ToDetails()).ToList();
        }
    }
}
