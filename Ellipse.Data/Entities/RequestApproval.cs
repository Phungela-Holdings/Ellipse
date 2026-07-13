using System.ComponentModel.DataAnnotations;

namespace Ellipse.Data.Entities
{
    public class RequestApproval
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public long PostId { get; set; }

        public long ServiceNumber { get; set; }

        public DateTime ApprovalDate { get; set; }

        public int RequestId { get; set; }

        public Request Request { get; set; }

        public string ApprovalType { get; set; }
    }
}