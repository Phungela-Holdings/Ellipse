using Ellipse.Core.Extensions;
using Ellipse.Data;
using Ellipse.Shared.DTOs;
using Ellipse.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ellipse.Core
{
    public class RequestApprovalService : IRequestApprovalService
    {
        private readonly EllipseDbContext _context;

        public RequestApprovalService(EllipseDbContext context)
        {
            _context = context;
        }

        public bool CreateApprovals(RequestApprovalDetails requestApprovalDetails)
        {
            var requestApproval = requestApprovalDetails.ToEntity();

            _context.RequestApprovals.Add(requestApproval);

            _context.SaveChanges();

            return true;
        }

        public List<RequestApprovalDetails> GetApprovalsForRequest(int requestId)
        {
            return _context.RequestApprovals
                           .Where(x => x.RequestId == requestId)
                           .ToList()
                           .ToListDetails();
        }
    }
}