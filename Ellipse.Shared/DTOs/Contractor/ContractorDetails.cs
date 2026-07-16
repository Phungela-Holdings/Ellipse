using System;
using System.Collections.Generic;
using System.Text;

namespace Ellipse.Shared.DTOs.Contract
{
    public class ContractorDetails
    {
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

        // ToDo: Add Request Summaries
    }

}
