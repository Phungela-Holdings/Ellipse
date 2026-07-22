using Ellipse.Data.Entities;
using Ellipse.Shared.DTOs.Request;

namespace Ellipse.Core.Extensions
{
    public static class RequestExtensions
    {
        public static void UpdateStatus(this Request request)
        {
            if (request.RequestClosed == true
                && request.HcOfficerApprovalId.HasValue
                && (request.ICTManagerApprovalId.HasValue || (request.TrainingApproverId.HasValue && request.TrainingCompletionDate.HasValue))
                && request.LineManagerApprovalId.HasValue)
            {
                request.Status = "Request Closed";
            }

            if (request.HcOfficerApprovalId == null
                && (request.ICTManagerApprovalId.HasValue || (request.TrainingApproverId.HasValue && request.TrainingCompletionDate.HasValue))
                && request.LineManagerApprovalId.HasValue)
            {
                request.Status = "Awaiting HC Officer Review";
            }

            if (request.Environment == "Production")
            {
                if (request.HcOfficerApprovalId == null
                    && request.TrainingApproverId == null
                    && request.TrainingCompletionDate == null
                    && request.LineManagerApprovalId.HasValue)
                {
                    request.Status = "Awaiting Training Verification";
                }
            }

            if (request.Environment == "Test" || request.Environment == "Development")
            {
                if (request.HcOfficerApprovalId == null
                    && request.ICTManagerApprovalId == null
                    && request.LineManagerApprovalId.HasValue)
                {
                    request.Status = "Awaiting ICT Manager Review";
                }
            }

            if (request.HcOfficerApprovalId == null
                && (request.ICTManagerApprovalId == null || (request.TrainingApproverId == null && request.TrainingCompletionDate == null))
                && request.LineManagerApprovalId == null)
            {
                request.Status = "Awaiting Line Manager Review";
            }
        }

        public static RequestSummary ToSummary(this Request request)
        {
            return new RequestSummary
            {
                AdditionalUserAccess = request.AdditionalUserAccess,
                Environment = request.Environment,
                Id = request.Id,
                RequestType = request.RequestType,
                Status = request.Status,
                UserAccessType = request.UserAccessType,
            };
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
                Documents = request.Documents.ToDetailsList(),
                Contractor = request.Contractor?.ToSummary(),
                TemporaryPosition = request.TemporaryPosition,
                TemporaryPostId = request.TemporaryPostId,
                MissingDocuments = request.MissingDocuments,
                LineManagerApproved = request.LineManagerApprover != null,
                TrainingVerified = request.TrainingApprover != null,
                ICTManagerApproved = request.ICTManagerApprover != null,
                HCSystemsAdminApproved = request.HcOfficerApprover != null,
                TrainingCompletionDate = request.TrainingCompletionDate,
                RequestClosed = request.RequestClosed,
                HcAdminApprovalId = request.HcOfficerApprovalId,
                LineManagerApprovalId = request.LineManagerApprovalId,
                TrainingApprovalId = request.TrainingApproverId,
                ICTManagerApprovalId = request.ICTManagerApprovalId,
                Employee = request.Employee?.ToSummary(),
            };
        }

        public static Request ToEntity(this RequestDetails requestDetails)
        {
            return new Request
            {
                EndDate = requestDetails.EndDate,
                Id = requestDetails.Id,
                RequestedDate = DateTime.Now,
                StartDate = requestDetails.StartDate,
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
                TemporaryPosition = requestDetails.TemporaryPosition,
                TemporaryPostId = requestDetails.TemporaryPostId,
                MissingDocuments = requestDetails.MissingDocuments,
                TrainingCompletionDate = requestDetails.TrainingCompletionDate,
                RequestClosed = requestDetails.RequestClosed,
                HcOfficerApprovalId = requestDetails.HcAdminApprovalId,
                LineManagerApprovalId = requestDetails.LineManagerApprovalId,
                TrainingApproverId = requestDetails.TrainingApprovalId,
                ICTManagerApprovalId = requestDetails.ICTManagerApprovalId,
            };
        }

        public static List<RequestDetails> ToListDetails(this List<Request> requests)
        {
            return requests.Select(request => request.ToDetails()).ToList();
        }
    }
}
