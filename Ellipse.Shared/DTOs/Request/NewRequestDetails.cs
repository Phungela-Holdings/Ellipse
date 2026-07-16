using Ellipse.Shared.DTOs.Contract;
using Ellipse.Shared.DTOs.Employee;

namespace Ellipse.Shared.DTOs.Request
{
    public class NewRequestDetails
    {
        public RequestDetails RequestDetails {get; set;}

        public EmployeeDetails? EmployeeDetails { get; set; }

        public ContractorDetails? ContractorDetails { get; set; }
    }
}