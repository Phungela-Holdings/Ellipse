using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ellipse.Data.Entities
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int RequestId { get; set; }

        [ForeignKey(nameof(RequestId))]
        public Request Request { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string RecipientEmail { get; set; }

        public DateTime SendDate { get; set; }

        [Required]
        public string Status { get; set; }
    }
}