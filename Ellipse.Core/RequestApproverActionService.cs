using Ellipse.Core.Extensions;
using Ellipse.Data;
using Ellipse.Shared.DTOs;
using Ellipse.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ellipse.Core
{
    public class RequestApproverActionService : IRequestApproverActionService
    {
        private readonly EllipseDbContext _context;

        public RequestApproverActionService(EllipseDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateApprovalsAsync(RequestApproverActionDetails requestApproverActionDetails)
        {
            var requestApproverAction = requestApproverActionDetails.ToEntity();

            await _context.RequestApproverActions.AddAsync(requestApproverAction);

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<RequestApproverActionDetails>> GetApprovalsForRequestAsync(int requestId)
        {
            var approvals = await _context.RequestApproverActions
                                          .Where(x => x.RequestId == requestId)
                                          .ToListAsync();

            return approvals.ToListDetails();
        }
    }
}