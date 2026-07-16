using System;
using System.Collections.Generic;
using System.Text;

namespace Ellipse.Shared.DTOs.Contract
{
    public class ContractorSummary
    {
        public int Id { get; set; }
        public string Surname { get; set; }

       public string FirstName { get; set; }
        public string EmailAddress { get; set; }
    }
}
