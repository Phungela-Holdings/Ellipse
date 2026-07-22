using Ellipse.Data.Entities;
using Ellipse.Shared.DTOs.Contractor;

namespace Ellipse.Core.Extensions
{
    public static class ContractorExtensions
    {
        public static ContractorDetails ToDetails(this Contractor contractor)
        {
            return new ContractorDetails
            {
                Id = contractor.Id,
                IdentificationNumber = contractor.IdentificationNumber,
                Surname = contractor.Surname,
                FirstName = contractor.FirstName,
                EmailAddress = contractor.EmailAddress,
                CompanyName = contractor.CompanyName,
                ResponsibleManager = contractor.ResponsibleManager,
                BusinessJustification = contractor.BusinessJustification,
                StartDate = contractor.StartDate,
                EndDate = contractor.EndDate,
                Department = contractor.Department,
                Branch = contractor.Branch,
                Requests = contractor.Requests.Select(o => o.ToSummary()).ToList(),
            };
        }

        public static Contractor ToEntity(this ContractorDetails contractorDetails)
        {
            return new Contractor
            {
                Id = contractorDetails.Id,
                IdentificationNumber = contractorDetails.IdentificationNumber,
                Surname = contractorDetails.Surname,
                FirstName = contractorDetails.FirstName,
                EmailAddress = contractorDetails.EmailAddress,
                CompanyName = contractorDetails.CompanyName,
                ResponsibleManager = contractorDetails.ResponsibleManager,
                BusinessJustification = contractorDetails.BusinessJustification,
                StartDate = contractorDetails.StartDate,
                EndDate = contractorDetails.EndDate,
                Department = contractorDetails.Department,
                Branch = contractorDetails.Branch
            };
        }

        public static ContractorSummary ToSummary(this Contractor contractor)
        {
            return new ContractorSummary
            {
                Id = contractor.Id,
                Surname = contractor.Surname,
                FirstName = contractor.FirstName,
                EmailAddress = contractor.EmailAddress,
            };
        }

    }
}
