using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ellipse.Data.Entities
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        public byte[] Data { get; set; }

        public DateTime DateUplouded { get; set; }

        public DateTime? DateModified { get; set; }

        public string DocumentType { get; set; }

        public int RequestId { get; set; }

        public bool IsActive { get; set; }

        public bool Archived { get; set; }

        public DateTime? ArchivedDate { get; set; }






    }
}
