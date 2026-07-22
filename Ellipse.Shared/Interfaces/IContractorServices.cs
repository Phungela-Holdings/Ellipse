using Ellipse.Shared.DTOs.Contractor;

namespace Ellipse.Shared.Interfaces
{
    public interface IContractorServices
    {
        Task<ContractorDetails> CreateContractorAsync(ContractorDetails contractorDetails);

        Task<ContractorDetails?> GetContractorByIdAsync(int contractorId);

        Task<ContractorDetails> UpdateContractorAsync(ContractorDetails contractorDetails);

        Task<bool> DeleteContractorAsync(int contractorId);

    }
}   
