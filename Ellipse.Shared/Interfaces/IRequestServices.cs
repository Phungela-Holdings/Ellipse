using Ellipse.Shared.DTOs.Request;

namespace Ellipse.Shared.Interfaces
{
    public interface IRequestServices
    {
        Task<List<RequestDetails>> GetRequests();

    }
}
