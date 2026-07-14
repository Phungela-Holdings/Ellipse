using System;
using System.ComponentModel.DataAnnotations;

namespace Ellipse.Data.Entities
{
    public class Request
    {
        public int Id { get; set; }

        [Required]
        public string Status { get; set; } // nvarchar(MAX)

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime RequestedDate { get; set; }

        [Required]
        public long EllipseUserId { get; set; }

        [Required]
        public string EllipsePosition { get; set; } // nvarchar(MAX)

        [Required]
        public string MenuAccess { get; set; } // nvarchar(MAX)

        [Required]
        public string BusinessJustification { get; set; } // nvarchar(MAX)

        [Required]
        public string RequestType { get; set; } // nvarchar(MAX)

        [Required]
        [StringLength(50)]
        public string Environment { get; set; }

        [Required]
        [StringLength(50)]
        public string UserAccessType { get; set; }

        [Required]
        [StringLength(50)]
        public string AdditionalUserAccess { get; set; }

        [Required]
        public long userId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserType { get; set; } 
    }
}