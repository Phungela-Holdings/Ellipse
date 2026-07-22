using Ellipse.Shared.DTOs;

namespace Ellipse.Shared.Interfaces
{
    public interface IRequestApproverActionService
    {
        Task<bool> CreateApproverActionAsync(RequestApproverActionDetails requestApprovalDetails);

        Task<List<RequestApproverActionDetails>> GetApproverActionForRequestAsync(int requestId);
    }
}