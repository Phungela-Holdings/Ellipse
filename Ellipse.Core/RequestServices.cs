using Ellipse.Core.Extensions;
using Ellipse.Data;
using Ellipse.Shared.DTOs.Request;
using Ellipse.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ellipse.Core
{
    public class RequestServices : IRequestServices
    {
        private readonly EllipseDbContext _context;

        public RequestServices(EllipseDbContext context)
        {
            _context = context;
        }

        public async Task<List<RequestDetails>> GetRequests()
        {
            var requests = await _context.Requests.ToListAsync();

            return requests .ToListDetails();
        }

        public Task<RequestDetails> CreateRequest(NewRequestDetails requestDetails)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<RequestDetails> GetRequest(int requestId)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<List<RequestDetails>> SearchRequest(string searchString)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<RequestDetails> UpdateRequest(RequestDetails requestDetails)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<bool> LineManagerRequestApproval(int requestId)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<bool> LineManagerRequestRejection(int requestId, string rejectionReason = null)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<bool> ICTManagerRequestApproval(int requestId)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<bool> ICTManagerRequestRejection(int requestId, string rejectionReason = null)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<bool> TrainingCenterRequestVerification(int requestId, DateTime trainingDate, string verifiedBy)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<bool> TrainingCenterRequestUnverified(int requestId, string rejectionReason = null)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<bool> HcSystemsAdminRequestImplementation(int requestId, DateTime accessImplementationDate, string ellipseUserId)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<bool> HcSystemsAdminRequestRejections(int requestId, string rejectionReason = null)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task UpdateRequestStatus()
        {
            // TODO: implement
            throw new NotImplementedException();
        }
    }
}