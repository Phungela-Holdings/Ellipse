using Ellipse.Shared.DTOs;
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

        Task<bool> LineManagerRequestApproval(int requestId, RequestApprovalDetails requestApproval);

        Task<bool> LineManagerRequestRejection(int requestId, RequestApprovalDetails requestApproval, string rejectionReason = null);

        Task<bool> ICTManagerRequestApproval(int requestId, RequestApprovalDetails requestApproval);

        Task<bool> ICTManagerRequestRejection(int requestId, RequestApprovalDetails requestApproval, string rejectionReason = null);

        Task<bool> TrainingCenterRequestVerification(int requestId, RequestApprovalDetails requestApproval, DateTime trainingDate, string verifiedBy);

        Task<bool> TrainingCenterRequestUnverified(int requestId, RequestApprovalDetails requestApproval, string rejectionReason = null);

        Task<bool> HcSystemsAdminRequestImplementation(int requestId, RequestApprovalDetails requestApproval, DateTime accessImplementationDate, string ellipseUserId);

        Task<bool> HcSystemsAdminRequestRejections(int requestId, RequestApprovalDetails requestApproval, string rejectionReason = null);
    }
}