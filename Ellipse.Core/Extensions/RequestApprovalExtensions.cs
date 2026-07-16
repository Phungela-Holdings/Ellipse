using Ellipse.Data.Entities;
using Ellipse.Shared.DTOs;
using Ellipse.Shared.Enums;

namespace Ellipse.Core.Extensions
{
    public static class RequestApprovalExtensions
    {
        public static RequestApprovalDetails ToDetails(this RequestApproval requestApproval)
        {
            return new RequestApprovalDetails
            {
                Id = requestApproval.Id,
                Name = requestApproval.Name,
                Surname = requestApproval.Surname,
                PostId = requestApproval.PostId,
                ServiceNumber = requestApproval.ServiceNumber,
                ApprovalDate = requestApproval.ApprovalDate,
                RequestId = requestApproval.RequestId,
                ApprovalType = requestApproval.ApprovalType.ToString(),
            };
        }

        public static RequestApproval ToEntity(this RequestApprovalDetails requestApprovalDetails)
        {
            return new RequestApproval
            {
                Id = requestApprovalDetails.Id,
                Name = requestApprovalDetails.Name,
                Surname = requestApprovalDetails.Surname,
                PostId = requestApprovalDetails.PostId,
                ServiceNumber = requestApprovalDetails.ServiceNumber,
                ApprovalDate = requestApprovalDetails.ApprovalDate,
                RequestId = requestApprovalDetails.RequestId,
                ApprovalType = Enum.Parse<ApprovalType>(requestApprovalDetails.ApprovalType),
            };
        }

        public static List<RequestApprovalDetails> ToListDetails(this List<RequestApproval> requestApprovals)
        {
            return requestApprovals.Select(requestApproval => requestApproval.ToDetails()).ToList();
        }
    }
}