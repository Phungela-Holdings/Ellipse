using Ellipse.Data.Entities;
using Ellipse.Shared.DTOs.Document;

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
                DateUploaded = document.DateUploaded,
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
                DateUploaded = DateTime.Now,
                DateModified = documentDetails.DateModified,
                DocumentType = documentDetails.DocumentType,
                RequestId = documentDetails.RequestId,
                IsActive = documentDetails.Active,
                Archived = documentDetails.Archived,
                ArchivedDate = documentDetails.ArchivedDate
            };
        }

        public static List<DocumentDetails> ToDetailsList(this List<Document> documents)
        {
            return documents.Select(document => document.ToDetails()).ToList();
        }
    }
}
