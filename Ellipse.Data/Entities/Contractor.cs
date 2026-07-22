using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ellipse.Data.Entities
{
    public class Contractor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string IdentificationNumber { get; set; }

        public string Surname { get; set; }

        public string FirstName { get; set; }

        public string EmailAddress { get; set; }

        public string CompanyName { get; set; }

        public string ResponsibleManager { get; set; }

        public string BusinessJustification { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Department { get; set; }

        public string Branch { get; set; }

        public bool Active { get; set; }

       public List<Request> Requests { get; set; } = new();
    }
}



