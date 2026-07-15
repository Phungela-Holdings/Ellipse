using Ellipse.Shared.DTOs.Request;

namespace Ellipse.Shared.Interfaces
{
    public interface IRequestServices
    {
        Task<RequestDetails> CreateRequest(NewRequestDetails requestDetails);

        Task<List<RequestDetails>> GetRequests();

        Task<RequestDetails> GetRequest(int requestId);

        Task<List<RequestDetails>> SearchRequest(string searchString);

        Task<RequestDetails> UpdateRequest(RequestDetails requestDetails);

        Task<bool> LineManagerRequestApproval(int requestId);

        Task<bool> LineManagerRequestRejection(int requestId, string rejectionReason = null);

        Task<bool> ICTManagerRequestApproval(int requestId);

        Task<bool> ICTManagerRequestRejection(int requestId, string rejectionReason = null);

        Task<bool> TrainingCenterRequestVerification(int requestId, DateTime trainingDate, string verifiedBy);

        Task<bool> TrainingCenterRequestUnverified(int requestId, string rejectionReason = null);

        Task<bool> HcSystemsAdminRequestImplementation(int requestId, DateTime accessImplementationDate, string ellipseUserId);

        Task<bool> HcSystemsAdminRequestRejections(int requestId, string rejectionReason = null);

        Task UpdateRequestStatus();
    }
}