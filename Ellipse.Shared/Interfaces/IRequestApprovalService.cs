using Ellipse.Shared.DTOs;

namespace Ellipse.Shared.Interfaces
{
    public interface IRequestApprovalService
    {
        bool CreateApprovals(RequestApprovalDetails requestApprovalDetails);

        List<RequestApprovalDetails> GetApprovalsForRequest(int requestId);
    }
}