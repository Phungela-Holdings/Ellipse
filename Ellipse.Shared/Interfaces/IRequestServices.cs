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

        Task<bool> LineManagerRequestApproval(RequestApproverActionDetails requestApprover);

        Task<bool> LineManagerRequestRejection(RequestApproverActionDetails requestApprover);

        Task<bool> ICTManagerRequestApproval(RequestApproverActionDetails requestApprover);

        Task<bool> ICTManagerRequestRejection(RequestApproverActionDetails requestApprover);

        Task<bool> TrainingCenterRequestVerification(RequestApproverActionDetails requestApprover, DateTime trainingDate, string verifiedBy);

        Task<bool> UnverifiedTraining(RequestApproverActionDetails requestApprover);

        Task<bool> HcOfficerRequestImplementation(RequestApproverActionDetails requestApprover, DateTime accessImplementationDate, long ellipseUserId);

        Task<bool> HcSystemsAdminRequestRejection(RequestApproverActionDetails requestApprover);
    }
}