using System;
using System.Collections.Generic;
using System.Text;

namespace Ellipse.Data.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Email_Address { get; set; }

        public int PostId { get; set; }

        public string Surname { get; set; }

        public string First_Name { get; set; }

        public string Contact_Number { get; set; }

        public string Service_Number { get; set; }

        public string Department { get; set; }

        public string Branch { get; set; }

        public string Designation { get; set; }

        public string ActiveDirectortyUsername { get; set; }

        public bool IsActive { get; set; }

        public List<Request> Requests { get; set; }
    }
}
