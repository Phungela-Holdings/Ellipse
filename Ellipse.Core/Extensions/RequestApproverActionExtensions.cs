using Ellipse.Data.Entities;
using Ellipse.Shared.DTOs.RequestApproverAction;
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
                ApproverDate = requestApproverAction.ActionDate,
                RequestId = requestApproverAction.RequestId,
                ApproverType = requestApproverAction.ApproverType,
                ActionType = requestApproverAction.ActionType
            };
        }

        public static RequestApproverAction ToEntity(this RequestApproverActionDetails requestApproverActionDetails, Request request, ApproverType approverType, ApproverActionType actionType)
        {
            return new RequestApproverAction
            {
                Id = requestApproverActionDetails.Id,
                Name = requestApproverActionDetails.Name,
                Surname = requestApproverActionDetails.Surname,
                PostId = requestApproverActionDetails.PostId,
                ServiceNumber = requestApproverActionDetails.ServiceNumber,
                ActionDate = requestApproverActionDetails.ApproverDate,
                ApproverType = approverType.GetDescription(),
                RequestId = request.Id,
                Request = request,
                ActionType = actionType.GetDescription()
            };
        }

        public static List<RequestApproverActionDetails> ToDetailsList(this List<RequestApproverAction> requestApproverActions)
        {
            return requestApproverActions.Select(requestApproverAction => requestApproverAction.ToDetails()).ToList();
        }
    }
}