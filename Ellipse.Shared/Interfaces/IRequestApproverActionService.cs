using Ellipse.Shared.DTOs.RequestApproverAction;

namespace Ellipse.Shared.Interfaces
{
    public interface IRequestApproverActionService
    {
        Task<List<RequestApproverActionDetails>> GetApproverActionForRequestAsync(int requestId);
    }
}