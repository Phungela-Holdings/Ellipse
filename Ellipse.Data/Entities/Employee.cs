using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ellipse.Data.Entities
{
    public class Employee
    {
        [Key]
        public string EmailAddress { get; set; }

        public int PostId { get; set; }

        public string Surname { get; set; }

        public string FirstName { get; set; }

        public string ContactNumber { get; set; }

        public string ServiceNumber { get; set; }

        public string Department { get; set; }

        public string Branch { get; set; }

        public string Designation { get; set; }

        public string ActiveDirectortyUsername { get; set; }

        public bool IsActive { get; set; }
    }
}
