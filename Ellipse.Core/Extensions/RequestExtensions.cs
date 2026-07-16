
using Ellipse.Data.Entities;
using Ellipse.Shared.DTOs.Request;

namespace Ellipse.Core.Extensions
{
    public static class RequestExtensions
    {
        public static void UpdateStatus(this Request request)
        {
            //ToDo: Implement logic to update the status of the request based on certain conditions
        }

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
                //Documents = request.Documents,
                ContractId = request.ContractId,
                //Contractor = request.Contractor,
                EmployeeEmail = request.EmployeeEmail,
                TemporaryPosition = request.TemporaryPosition,
                TemporaryPostId = request.TemporaryPostId,
                MissingDocuments = request.MissingDocuments,
                LineManagerApproved = request.LineManagerApproval != null,
                TrainingVerified = request.TrainingApproval != null,
                ICTManagerApproved = request.ICTManagerApproval != null,
                HCSystemsAdminApproved = request.HcAdminApproval != null,
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
                Status = requestDetails.Status
            };
        }

        public static List<RequestDetails> ToListDetails(this List<Request> requests)
        {
            return requests.Select(request => request.ToDetails()).ToList();
        }
    }
}
