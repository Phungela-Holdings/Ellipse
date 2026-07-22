using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ellipse.Data.Entities
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string EmailAddress { get; set; }

        public int PostId { get; set; }

        public string Surname { get; set; }

        public string FirstName { get; set; }

        public string ContactNumber { get; set; }

        public string ServiceNumber { get; set; }

        public string Department { get; set; }

        public string Branch { get; set; }

        public string Designation { get; set; }

        public string ActiveDirectoryUsername { get; set; }

        public bool IsActive { get; set; }

        public string ResponsibleManager { get; set; }

        public List<Request> Requests { get; set; }
    }
}
