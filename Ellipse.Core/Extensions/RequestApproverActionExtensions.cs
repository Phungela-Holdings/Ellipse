using Ellipse.Data.Entities;
using Ellipse.Shared.DTOs;
using Ellipse.Shared.Enums;

namespace Ellipse.Core.Extensions
{
    public static class RequestApprovalExtensions
    {
        public static RequestApproverActionDetails ToDetails(this RequestApproverAction requestApproverAction)
        {
            return new RequestApproverActionDetails
            {
                Id = requestApproverAction.Id,
                Name = requestApproverAction.Name,
                Surname = requestApproverAction.Surname,
                PostId = requestApproverAction.PostId,
                ServiceNumber = requestApproverAction.ServiceNumber,
                ApproverDate = requestApproverAction.ApproverDate,
                RequestId = requestApproverAction.RequestId,
                ApproverType = requestApproverAction.ApproveType.ToString(),
            };
        }

        public static RequestApproverAction ToEntity(this RequestApproverActionDetails requestApproverActionDetails)
        {
            return new RequestApproverAction
            {
                Id = requestApproverActionDetails.Id,
                Name = requestApproverActionDetails.Name,
                Surname = requestApproverActionDetails.Surname,
                PostId = requestApproverActionDetails.PostId,
                ServiceNumber = requestApproverActionDetails.ServiceNumber,
                ApproverDate = requestApproverActionDetails.ApproverDate,
                RequestId = requestApproverActionDetails.RequestId,
                ApproveType = Enum.Parse<ApproveType>(requestApproverActionDetails.ApproverType),
            };
        }

        public static List<RequestApproverActionDetails> ToListDetails(this List<RequestApproverAction> requestApproverActions)
        {
            return requestApproverActions.Select(requestApproverAction => requestApproverAction.ToDetails()).ToList();
        }
    }
}