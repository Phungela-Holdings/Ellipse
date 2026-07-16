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
                Status = request.Status,
                EllipseUserId = request.EllipseUserId,
                EllipsePosition = request.EllipsePosition,
                MenuAccess = request.MenuAccess,
                BusinessJustification = request.BusinessJustification,
                RequestType = request.RequestType,
                Environment = request.Environment,
                UserAccessType = request.UserAccessType,
                AdditionalUserAccess = request.AdditionalUserAccess,
                userId = request.userId,
                UserType = request.UserType,
                //Documents = request.Document  To do
                //Contractor = request.Contractor  To do
                TemporaryPosition = request.TemporaryPosition,
                TemporaryPostId = request.TemporaryPostId,
                MissingDocuments = request.MissingDocuments,
                LineManagerApproved = request.LineManagerApproved,
                TrainingVerified = request.TrainingVerified,
                ICTManagerApproved = request.ICTManagerApproved,
                HCSystemsAdminApproved = request.HCSystemsAdminApproved,
                TrainingCompletionDate = request.TrainingCompletionDate,
                RequestClosed = request.RequestClosed,
                HcAdminApprovalId = request.HcAdminApprovalId,
                LineManagerApprovalId = request.LineManagerApprovalId,
                TrainingApprovalId = request.TrainingApprovalId,
                ICTManagerApprovalId = request.ICTManagerApprovalId,
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
                Status = requestDetails.Status,
                EllipseUserId = requestDetails.EllipseUserId,
                EllipsePosition = requestDetails.EllipsePosition,
                MenuAccess = requestDetails.MenuAccess,
                BusinessJustification = requestDetails.BusinessJustification,
                RequestType = requestDetails.RequestType,
                Environment = requestDetails.Environment,
                UserAccessType = requestDetails.UserAccessType,
                AdditionalUserAccess = requestDetails.AdditionalUserAccess,
                userId = requestDetails.userId,
                UserType = requestDetails.UserType,
                //Documents = requestDetails.Document  To do
                //Contractor = requestDetails.Contractor  To do
                TemporaryPosition = requestDetails.TemporaryPosition,
                TemporaryPostId = requestDetails.TemporaryPostId,
                MissingDocuments = requestDetails.MissingDocuments,
                LineManagerApproved = requestDetails.LineManagerApproved,
                TrainingVerified = requestDetails.TrainingVerified,
                ICTManagerApproved = requestDetails.ICTManagerApproved,
                HCSystemsAdminApproved = requestDetails.HCSystemsAdminApproved,
                TrainingCompletionDate = requestDetails.TrainingCompletionDate,
                RequestClosed = requestDetails.RequestClosed,
                HcAdminApprovalId = requestDetails.HcAdminApprovalId,
                LineManagerApprovalId = requestDetails.LineManagerApprovalId,
                TrainingApprovalId = requestDetails.TrainingApprovalId,
                ICTManagerApprovalId = requestDetails.ICTManagerApprovalId,
            };
        }

        public static List<RequestDetails> ToListDetails(this List<Request> requests)
        {
            return requests.Select(request => request.ToDetails()).ToList();
        }
    }
}
