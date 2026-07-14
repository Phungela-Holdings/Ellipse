using System;
using System.Collections.Generic;
using System.Text;

namespace Ellipse.Data.Entities
{
    public class DocumentAccess
    {
        public int Id { get; set; }

        public int DocumentId { get; set; }

        public DateTime DateAccessed { get; set; }

        public string AccessedBy { get; set; }

        
    }
}
