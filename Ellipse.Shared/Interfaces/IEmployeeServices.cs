using Ellipse.Shared.DTOs.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ellipse.Shared.Interfaces
{
    public interface IEmployeeServices
    {
        Task<EmployeeDetails> CreateEmployeeAsync(EmployeeDetails employeeDetails);

        Task<EmployeeDetails> GetEmployeeByIdAsync(string email);

        Task<EmployeeDetails> UpdateEmployeeAsync(EmployeeDetails employeeDetails);

        Task<bool> DeleteEmployeeAsync(string email);
    }
}
