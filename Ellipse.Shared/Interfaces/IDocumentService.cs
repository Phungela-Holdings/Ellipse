using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Ellipse.Shared.Interfaces
{
        namespace Ellipse.Shared.Interfaces
        {
        public interface IDocumentService
        {
            Document CreateDocument(Document documemt);
            Document GetDocumentById(Document document);
            List<Document> GetRequestDocument(int requestId);
            Document UpdateDocument(Document document);
            bool DeleteDocument(int documentId);
            bool ArchiveDocument(int documentId);
            byte[] DownloadDocument(int documentId);
        }


        }
           
}
