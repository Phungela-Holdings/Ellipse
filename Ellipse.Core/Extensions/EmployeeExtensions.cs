using Ellipse.Shared.DTOs.Employee;
using Ellipse.Data.Entities;

namespace Ellipse.Core.Extensions
{
    public static class EmployeeExtensions
    {
        public static EmployeeDetails ToDetails(this Employee employee)
        {
            return new EmployeeDetails
            {
                EmailAddress = employee.EmailAddress,

                PostId = employee.PostId,

                Surname=employee.Surname,

                FirstName=employee.FirstName,

                ContactNumber=employee.ContactNumber,

                ServiceNumber=employee.ServiceNumber,

                Department=employee.Department,

                Branch=employee.Branch,

                Designation=employee.Designation,

                ActiveDirectoryUsername=employee.ActiveDirectoryUsername,
            };
        }
        public static Employee ToEntity(this EmployeeDetails employee)
        {
            return new Employee
            {
                EmailAddress = employee.EmailAddress,

                PostId = employee.PostId,

                Surname = employee.Surname,

                FirstName = employee.FirstName,

                ContactNumber = employee.ContactNumber,

                ServiceNumber = employee.ServiceNumber,

                Department = employee.Department,

                Branch = employee.Branch,

                Designation = employee.Designation,

                ActiveDirectoryUsername = employee.ActiveDirectoryUsername,
            };
        }
        public static EmployeeSummary ToSummary(this Employee employee)
        {
            return new EmployeeSummary
            {
                EmailAddress = employee.EmailAddress,

                Surname = employee.Surname,

                FirstName = employee.FirstName,

                ServiceNumber = employee.ServiceNumber,

                Department = employee.Department,
            };
        }

        public static List<EmployeeDetails> ToListDetails(this List<Employee> employees)
        {
            return employees.Select(employee => employee.ToDetails()).ToList();
        }
    }
}
