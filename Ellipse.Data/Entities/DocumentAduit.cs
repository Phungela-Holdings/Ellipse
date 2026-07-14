using System;
using System.Collections.Generic;
using System.Text;

namespace Ellipse.Data.Entities
{
    public class DocumentAudit
    {


        public int Id { get; set; }
        public int DocumentId { get; set; }

        public DateTime DateCreated {get; set; } 
        public string AuditType { get; set; }
        public Byte DocumentData { get; set; }
        public Byte OldDocumentData { get; set; }


    }
}
