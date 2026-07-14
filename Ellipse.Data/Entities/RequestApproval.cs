using Ellipse.Shared.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ellipse.Data.Entities
{
    public class RequestApproval
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

       
        public string Name { get; set; }


        public string Surname { get; set; }

    
        public int PostId { get; set; }

     
        public int ServiceNumber { get; set; }

       
        public DateTime ApprovalDate { get; set; }

    
        public int RequestId { get; set; }


     
      public ApproveType ApprovalType { get; set; }

        public Request Request { get; set; }
    }
}