using System.Collections.Generic;
using System.Linq;
using Ellipse.Data.Entities;
using Ellipse.Shared.DTOs.DocumentDetails;

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
                Active = document.Active,
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
                DateUploaded = documentDetails.DateUploaded,
                DateModified = documentDetails.DateModified,
                DocumentType = documentDetails.DocumentType,
                RequestId = documentDetails.RequestId,
                Active = documentDetails.Active,
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
