using System;
using System.Collections.Generic;
using System.Text;

namespace Ellipse.Shared.DTOs.Employee
{
    public class EmployeeDetails
    {
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
        //ToDo:Add request sumarries
    }
}
