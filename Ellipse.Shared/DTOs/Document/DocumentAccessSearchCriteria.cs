using System;
using System.Collections.Generic;
using System.Text;

namespace Ellipse.Shared.DTOs.Document
{
    public class DocumentAccessSearchCriteria
    {
        /// <summary>
        /// Gets or sets the document ID to filter access records by.
        /// </summary>
        public int? DocumentId { get; set; }

        /// <summary>
        /// Gets or sets the user name to filter access records by.
        /// </summary>
        public string AccessedBy { get; set; }

        /// <summary>
        /// Gets or sets the start date for filtering access records.
        /// </summary>
        public DateTime? DateAccessedFrom { get; set; }

        /// <summary>
        /// Gets or sets the end date for filtering access records.
        /// </summary>
        public DateTime? DateAccessedTo { get; set; }

        /// <summary>
        /// Gets or sets the page number for pagination.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Gets or sets the page size for pagination.
        /// </summary>
        public int PageSize { get; set; }
    }
}
