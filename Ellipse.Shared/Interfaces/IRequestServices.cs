using Ellipse.Shared.DTOs.Request;
using Ellipse.Shared.DTOs.RequestApproverAction;

namespace Ellipse.Shared.Interfaces
{
    public interface IRequestServices
    {
        Task<RequestDetails> CreateRequest(NewRequestDetails requestDetails);

        Task<List<RequestDetails>> GetRequests();

        Task<RequestDetails> GetRequestDetails(int requestId);

        Task<List<RequestDetails>> SearchRequest(string searchString);

        Task<RequestDetails> UpdateRequest(RequestDetails requestDetails);

        Task<bool> LineManagerRequestApproval(int requestId, RequestApproverActionDetails requestApprover);

        Task<bool> LineManagerRequestRejection(int requestId, RequestApproverActionDetails requestApprover, string rejectionReason);

        Task<bool> ICTManagerRequestApproval(int requestId, RequestApproverActionDetails requestApprover);

        Task<bool> ICTManagerRequestRejection(int requestId, RequestApproverActionDetails requestApprover, string rejectionReason);

        Task<bool> TrainingCenterRequestVerification(int requestId, RequestApproverActionDetails requestApprover, DateTime trainingDate, string verifiedBy);

        Task<bool> UnverifiedTraining(int requestId, RequestApproverActionDetails requestApprover, string rejectionReason);

        Task<bool> HcOfficerRequestImplementation(int requestId, RequestApproverActionDetails requestApprover, DateTime accessImplementationDate, long ellipseUserId);

        Task<bool> HcSystemsAdminRequestRejection(int requestId, RequestApproverActionDetails requestApprover, string rejectionReason);
    }
}