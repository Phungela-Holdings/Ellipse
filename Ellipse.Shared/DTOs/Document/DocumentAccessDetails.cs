using System;
using System.Collections.Generic;
using System.Text;

namespace Ellipse.Shared.DTOs.Document
{
    public class DocumentAccessDetails
    {
        /// <summary>
        /// Gets or sets the unique identifier for the document access record.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///Gets or sets the ID the document that was accessed.
        /// </summary>
        public int DocumentId { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the document was accessed.
        /// </summary>
        public DateTime DateAccessed { get; set; }

        /// <summary>
        /// Gets or sets the name of the user who accessed or downloaded the document.
        /// </summary>
        public string AccessedBy { get; set; }
    }
}
