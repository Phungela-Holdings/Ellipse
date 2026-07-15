using Ellipse.Shared.DTOs.Contract;
using Ellipse.Shared.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Text;

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
