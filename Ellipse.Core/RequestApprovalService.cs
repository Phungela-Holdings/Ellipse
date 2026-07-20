using Ellipse.Core.Extensions;
using Ellipse.Data;
using Ellipse.Shared.DTOs;
using Ellipse.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ellipse.Core
{
    public class RequestApprovalService : IRequestApprovalService
    {
        private readonly EllipseDbContext _context;

        public RequestApprovalService(EllipseDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateApprovalsAsync(RequestApprovalDetails requestApprovalDetails)
        {
            var requestApproval = requestApprovalDetails.ToEntity();

            await _context.RequestApprovals.AddAsync(requestApproval);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<RequestApprovalDetails>> GetApprovalsForRequestAsync(int requestId)
        {
            var approvals = await _context.RequestApprovals
                                          .Where(x => x.RequestId == requestId)
                                          .ToListAsync();

            return approvals.ToListDetails();
        }
    }
}