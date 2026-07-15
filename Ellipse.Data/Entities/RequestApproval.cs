using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ellipse.Shared.Enums;

namespace Ellipse.Data.Entities
{
    public class RequestApproval
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

       
        public string Name { get; set; }


        public string Surname { get; set; }

        public long PostId { get; set; }

        public long ServiceNumber { get; set; }

        public DateTime ApprovalDate { get; set; }

    
        public int RequestId { get; set; }

        [ForeignKey(nameof(RequestId))]
        public Request Request { get; set; }

        public ApprovalType ApprovalType { get; set; }
    }
}