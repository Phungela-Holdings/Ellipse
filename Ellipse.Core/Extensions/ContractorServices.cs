using Ellipse.Core.Extensions;
using Ellipse.Data;
using Ellipse.Shared.DTOs.Contract;
using Ellipse.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ellipse.Core
{
    public class ContractorServices : IContractorServices
    {
        private readonly EllipseDbContext _context;

        public ContractorServices(EllipseDbContext context)
        {
            _context = context;
        }

        public async Task<ContractorDetails> CreateContractorAsync(ContractorDetails contractorDetails)
        {
            var contractor = contractorDetails.ToEntity();

            _context.Contractors.Add(contractor);
            await _context.SaveChangesAsync();

            return contractor.ToDetails();
        }

        public async Task<ContractorDetails?> GetContractorByIdAsync(int contractorId)
        {
            var contractor = await _context.Contractors.FindAsync(contractorId);

            return contractor?.ToDetails();
        }

        public async Task<ContractorDetails> UpdateContractorAsync(ContractorDetails contractorDetails)
        {
            var contractor = await _context.Contractors.FindAsync(contractorDetails.Id);

            if (contractor == null)
            {
                return null;
            }

            contractor.IdentificationNumber = contractorDetails.IdentificationNumber;
            contractor.Surname = contractorDetails.Surname;
            contractor.FirstName = contractorDetails.FirstName;
            contractor.EmailAddress = contractorDetails.EmailAddress;
            contractor.CompanyName = contractorDetails.CompanyName;
            contractor.ResponsibleManager = contractorDetails.ResponsibleManager;
            contractor.BusinessJustification = contractorDetails.BusinessJustification;
            contractor.StartDate = contractorDetails.StartDate;
            contractor.EndDate = contractorDetails.EndDate;
            contractor.Department = contractorDetails.Department;
            contractor.Branch = contractorDetails.Branch;

            await _context.SaveChangesAsync();

            return contractor.ToDetails();
        }

        public async Task<bool> DeleteContractorAsync(int contractorId)
        {
            var contractor = await _context.Contractors.FindAsync(contractorId);

            if (contractor == null)
            {
                return false;
            }
            await _context.SaveChangesAsync();

            return true;
        }
    }
}