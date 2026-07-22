using Ellipse.Core.Extensions;
using Ellipse.Data;
using Ellipse.Shared.DTOs.RequestApproverAction;
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

        public async Task<List<RequestApproverActionDetails>> GetApproverActionForRequestAsync(int requestId)
        {
            var approvals = await _context.RequestApproverActions
                                          .Where(x => x.RequestId == requestId)
                                          .ToListAsync();

            return approvals.ToDetailsList();
        }
    }
}