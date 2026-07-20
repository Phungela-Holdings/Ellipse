using Ellipse.Core.Extensions;
using Ellipse.Data;
using Ellipse.Data.Entities;
using Ellipse.Shared.DTOs;
using Ellipse.Shared.DTOs.Request;
using Ellipse.Shared.Enums;
using Ellipse.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ellipse.Core
{
    public class RequestServices : IRequestServices
    {
        private readonly EllipseDbContext _context;

        public RequestServices(EllipseDbContext context)
        {
            _context = context;
        }

        public async Task<List<RequestDetails>> GetRequests()
        {
            var requests = await _context.Requests.ToListAsync();

            return requests.ToListDetails();
        }

        public async Task<RequestDetails> CreateRequest(NewRequestDetails requestDetails)
        {
            if (requestDetails?.RequestDetails == null)
                throw new ArgumentException("RequestDetails cannot be null.");

            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var request = requestDetails.RequestDetails.ToEntity();

                if (requestDetails.EmployeeDetails != null)
                {
                    var employee = await _context.Employees
                        .FindAsync(requestDetails.EmployeeDetails.EmailAddress);

                    if (employee == null)
                    {
                        employee = requestDetails.EmployeeDetails.ToEntity();

                        await _context.Employees.AddAsync(employee);
                        await _context.SaveChangesAsync();
                    }

                    // Previously only set when a NEW employee was created, so
                    // requests linked to an existing employee never got the
                    // relationship set. Now set unconditionally.
                    request.Employee = employee;
                }

                if (requestDetails.ContractorDetails != null)
                {
                    var contractor = await _context.Contractors
                        .FindAsync(requestDetails.ContractorDetails.Id);

                    if (contractor == null)
                    {
                        contractor = requestDetails.ContractorDetails.ToEntity();

                        await _context.Contractors.AddAsync(contractor);
                        await _context.SaveChangesAsync();
                    }

                    // Same fix as above, for contractors.the contractor relationship is now set unconditionally.
                    request.Contractor = contractor;
                }

                request.UpdateStatus();
                await _context.Requests.AddAsync(request);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return request.ToDetails();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<RequestDetails> GetRequest(int requestId)
        {
            var request = await _context.Requests
                .FirstOrDefaultAsync(r => r.Id == requestId);

            if (request == null)
                throw new KeyNotFoundException($"Request with Id {requestId} was not found.");

            return request.ToDetails();
        }

        public async Task<List<RequestDetails>> SearchRequest(string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return await GetRequests();

            var term = searchString.Trim().ToLower();

            var requests = await _context.Requests
                .Include(r => r.Employee)
                .Include(r => r.Contractor)
                .Where(r =>
                    r.Status.ToLower().Contains(term) ||
                    (r.Employee != null && r.Employee.EmailAddress.ToLower().Contains(term)) ||
                    (r.Contractor != null && r.Contractor.FirstName.ToLower().Contains(term)))
                .ToListAsync();

            return requests.ToListDetails();
        }

        public async Task<RequestDetails> UpdateRequest(RequestDetails requestDetails)
        {
            var existing = await _context.Requests
                .FirstOrDefaultAsync(r => r.Id == requestDetails.Id);

            if (existing == null)
                throw new KeyNotFoundException($"Request with Id {requestDetails.Id} was not found.");

            existing.Status = requestDetails.Status;
            existing.StartDate = requestDetails.StartDate;
            existing.EndDate = requestDetails.EndDate;
            existing.EllipseUserId = requestDetails.EllipseUserId;
            existing.EllipsePosition = requestDetails.EllipsePosition;
            existing.MenuAccess = requestDetails.MenuAccess;
            existing.BusinessJustification = requestDetails.BusinessJustification;
            existing.RequestType = requestDetails.RequestType;
            existing.Environment = requestDetails.Environment;
            existing.UserAccessType = requestDetails.UserAccessType;
            existing.AdditionalUserAccess = requestDetails.AdditionalUserAccess;
            existing.userId = requestDetails.userId;
            existing.UserType = requestDetails.UserType;
            existing.TemporaryPosition = requestDetails.TemporaryPosition;
            existing.TemporaryPostId = requestDetails.TemporaryPostId;

            await _context.SaveChangesAsync();

            return existing.ToDetails();
        }

        public async Task<bool> LineManagerRequestApproval(int requestId, RequestApprovalDetails requestApproval)
        {
            var request = await GetRequestOrThrow(requestId);

            var approval = BuildApprovalEntity(requestApproval, request, ApprovalType.LineManager);

            await _context.RequestApprovals.AddAsync(approval);

            // Linking the approval record is what represents "approved" for
            // this stage - Request has no separate boolean flag.
            request.LineManagerApproval = approval;
            request.UpdateStatus();

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> LineManagerRequestRejection(int requestId, RequestApprovalDetails requestApproval, string rejectionReason)
        {
            var request = await GetRequestOrThrow(requestId);

            // No approval record is created on rejection - only an approved
            // stage gets a linked RequestApproval. The rejection itself is
            // recorded on Request.Rejection.
            request.Rejection = BuildRejectionMessage(requestApproval, "Line Manager", rejectionReason);
            request.UpdateStatus();

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ICTManagerRequestApproval(int requestId, RequestApprovalDetails requestApproval)
        {
            var request = await GetRequestOrThrow(requestId);

            var approval = BuildApprovalEntity(requestApproval, request, ApprovalType.ICTManager);

            await _context.RequestApprovals.AddAsync(approval);

            request.ICTManagerApproval = approval;
            request.UpdateStatus();

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ICTManagerRequestRejection(int requestId, RequestApprovalDetails requestApproval, string rejectionReason)
        {
            var request = await GetRequestOrThrow(requestId);

            request.Rejection = BuildRejectionMessage(requestApproval, "ICT Manager", rejectionReason);
            request.UpdateStatus();

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> HcSystemsAdminRequestRejections(int requestId, string rejectionReason = null)
        {
            var request = await GetRequestOrThrow(requestId);

            request.Rejection = BuildRejectionMessage(null, "HC Systems Administrator", rejectionReason);
            request.UpdateStatus();

            await _context.SaveChangesAsync();

            return true;
        }

        public Task<bool> TrainingCenterRequestVerification(int requestId, RequestApprovalDetails requestApproval, DateTime trainingDate, string verifiedBy)
        {
            return TrainingCenterRequestVerification(requestId, requestApproval, ApprovalType.FundamentalsTrainingComplete, trainingDate, verifiedBy);
        }

        // Overload allowing the caller to specify which training approval type
        // is being recorded (NavigationTrainingComplete or
        // FundamentalsTrainingComplete), since both share this workflow step.
        private async Task<bool> TrainingCenterRequestVerification(int requestId, RequestApprovalDetails requestApproval, ApprovalType approvalType, DateTime trainingDate, string verifiedBy)
        {
            var request = await GetRequestOrThrow(requestId);

            var approval = BuildApprovalEntity(requestApproval, request, approvalType);

            await _context.RequestApprovals.AddAsync(approval);

            request.TrainingApproval = approval;
            request.TrainingCompletionDate = trainingDate;
            request.UpdateStatus();

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> HcSystemsAdminRequestRejections(int requestId, RequestApprovalDetails requestApproval, string rejectionReason = null)
        {
            var request = await GetRequestOrThrow(requestId);

            request.Rejection = BuildRejectionMessage(requestApproval, "HC Systems Administrator", rejectionReason);
            request.UpdateStatus();

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> HcSystemsAdminRequestImplementation(int requestId, RequestApprovalDetails requestApproval, DateTime accessImplementationDate, string ellipseUserId)
        {
            var request = await GetRequestOrThrow(requestId);

            if (!long.TryParse(ellipseUserId, out var parsedEllipseUserId))
                throw new ArgumentException($"'{ellipseUserId}' is not a valid Ellipse user id.", nameof(ellipseUserId));

            var approval = BuildApprovalEntity(requestApproval, request, ApprovalType.HCSystemsAdministrator);

            await _context.RequestApprovals.AddAsync(approval);

            request.HcAdminApproval = approval;
            request.EllipseUserId = parsedEllipseUserId;
            request.RequestClosed = true;
            request.UpdateStatus();

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> TrainingCenterRequestUnverified(int requestId, RequestApprovalDetails requestApproval, string rejectionReason = null)
        {
            var request = await GetRequestOrThrow(requestId);

            request.Rejection = BuildRejectionMessage(requestApproval, "Training verification", rejectionReason);
            request.UpdateStatus();

            await _context.SaveChangesAsync();

            return true;
        }

        private async Task<Request> GetRequestOrThrow(int requestId)
        {
            var request = await _context.Requests
                .FirstOrDefaultAsync(r => r.Id == requestId);

            if (request == null)
                throw new KeyNotFoundException($"Request with Id {requestId} was not found.");

            return request;
        }

        // Builds a RequestApproval entity from the caller-supplied details.
        // Assumes RequestApprovalDetails exposes Name, Surname, PostId and
        // ServiceNumber, matching the RequestApproval entity; adjust property
        // names here if your DTO differs.
        private static RequestApproval BuildApprovalEntity(RequestApprovalDetails requestApproval, Request request, ApprovalType approvalType)
        {
            if (requestApproval == null)
                throw new ArgumentException("RequestApprovalDetails cannot be null.", nameof(requestApproval));

            return new RequestApproval
            {
                Name = requestApproval.Name,
                Surname = requestApproval.Surname,
                PostId = requestApproval.PostId,
                ServiceNumber = requestApproval.ServiceNumber,
                ApprovalDate = DateTime.UtcNow,
                ApprovalType = approvalType,
                RequestId = request.Id,
                Request = request
            };
        }

        // Builds the text stored in Request.Rejection - the only place a
        // rejection reason/stage can currently be recorded, since Request has
        // no per-stage rejection flag or reason column.
        private static string BuildRejectionMessage(RequestApprovalDetails requestApproval, string stage, string rejectionReason)
        {
            var rejectedBy = requestApproval != null
                ? $"{requestApproval.Name} {requestApproval.Surname}".Trim()
                : null;

            var prefix = string.IsNullOrEmpty(rejectedBy)
                ? $"{stage} rejection"
                : $"{stage} rejection by {rejectedBy}";

            return string.IsNullOrWhiteSpace(rejectionReason)
                ? $"{prefix}."
                : $"{prefix}: {rejectionReason}";
        }
    }
}