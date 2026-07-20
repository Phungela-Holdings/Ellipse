using Ellipse.Shared.DTOs;

namespace Ellipse.Shared.Interfaces
{
    public interface IRequestApprovalService
    {
        Task<bool> CreateApprovalsAsync(RequestApprovalDetails requestApprovalDetails);

        Task<List<RequestApprovalDetails>> GetApprovalsForRequestAsync(int requestId);
    }
}