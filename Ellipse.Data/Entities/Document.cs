using System;
using System.Collections.Generic;
using System.Text;

namespace Ellipse.Data.Entities
{
    public class Document
    {
        public int DocumentId { get; set; }

        public byte Data { get; set; }

        public DateTime Date_Uplouded { get; set; }

        public DateTime Date_Modified { get; set; }

        public string Document_Type { get; set; }

        public int RequestId { get; set; }

        public bool IsActive { get; set; }

        public bool Archived { get; set; }

        public DateTime Archived_Date { get; set; }






    }
}
