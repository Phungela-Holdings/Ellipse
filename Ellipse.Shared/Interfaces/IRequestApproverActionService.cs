using Ellipse.Shared.DTOs;

namespace Ellipse.Shared.Interfaces
{
    public interface IRequestApproverActionService
    {
        public interface IRequestApproverActionService
        {
            Task<bool> CreateApprovalsAsync(RequestApproverActionDetails requestApprovalDetails);

            Task<List<RequestApproverActionDetails>> GetApprovalsForRequestAsync(int requestId);
        }
    }
}