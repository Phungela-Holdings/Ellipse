
using Ellipse.Data.Entities;
using Ellipse.Shared.DTOs.Request;

namespace Ellipse.Core.Extensions
{
    public static class RequestExtensions
    {
        public static RequestDetails ToDetails(this Request request)
        {
            return new RequestDetails
            {
                EndDate = request.EndDate,
                Id = request.Id,
                RequestedDate = request.RequestedDate,
                StartDate = request.StartDate,
                Status = request.Status
            };
        }

        public static Request ToEntity(this RequestDetails requestDetails)
        {
            return new Request
            {
                EndDate = requestDetails.EndDate,
                Id = requestDetails.Id,
                RequestedDate = requestDetails.RequestedDate,
                StartDate = requestDetails.StartDate,
                Status = requestDetails.Status
            };
        }

        public static List<RequestDetails> ToListDetails(this List<Request> requests)
        {
            return requests.Select(request => request.ToDetails()).ToList();
        }
    }
}
