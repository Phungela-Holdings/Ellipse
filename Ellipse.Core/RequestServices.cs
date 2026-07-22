using Ellipse.Core.Extensions;
using Ellipse.Data;
using Ellipse.Data.Entities;
using Ellipse.Shared.DTOs.Request;
using Ellipse.Shared.DTOs.RequestApproverAction;
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

        public async Task<RequestDetails> CreateRequest(NewRequestDetails newRequestDetails)
        {
            if (newRequestDetails?.RequestDetails == null)
                throw new ArgumentException("RequestDetails cannot be null.");

            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var request = newRequestDetails.RequestDetails.ToEntity();

                if (newRequestDetails.EmployeeDetails != null)
                {
                    var employee = await _context.Employees
                        .FindAsync(newRequestDetails.EmployeeDetails.EmailAddress);

                    if (employee == null)
                    {
                        employee = newRequestDetails.EmployeeDetails.ToEntity();

                        await _context.Employees.AddAsync(employee);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        var employeeService = new EmployeeServices(_context);
                        await employeeService.UpdateEmployeeAsync(newRequestDetails.EmployeeDetails);
                    }

                    request.Employee = employee;
                }

                if (newRequestDetails.ContractorDetails != null)
                {
                    var contractor = await _context.Contractors
                        .FindAsync(newRequestDetails.ContractorDetails.Id);

                    if (contractor == null)
                    {
                        contractor = newRequestDetails.ContractorDetails.ToEntity();

                        await _context.Contractors.AddAsync(contractor);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        var contractorServices = new ContractorServices(_context);
                        await contractorServices.UpdateContractorAsync(newRequestDetails.ContractorDetails);
                    }
                    
                    request.Contractor = contractor;
                }

                request.UpdateStatus();
                await _context.Requests.AddAsync(request);
                await _context.SaveChangesAsync();

                if (newRequestDetails.Documents != null && newRequestDetails.Documents.Any())
                {
                    foreach (var documentDetails in newRequestDetails.Documents)
                    {
                        var document = documentDetails.ToEntity();
                        document.RequestId = request.Id;

                        await _context.Documents.AddAsync(document);
                        await _context.SaveChangesAsync();
                    }
                }

                await transaction.CommitAsync();

                return request.ToDetails();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<RequestDetails> GetRequestDetails(int requestId)
        {
            var request = await GetRequest(requestId);

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
            var request = await _context.Requests
                .FirstOrDefaultAsync(r => r.Id == requestDetails.Id);

            if (request == null)
                throw new KeyNotFoundException($"Request with Id {requestDetails.Id} was not found.");

            request.StartDate = requestDetails.StartDate;
            request.EndDate = requestDetails.EndDate;
            request.EllipseUserId = requestDetails.EllipseUserId;
            request.EllipsePosition = requestDetails.EllipsePosition;
            request.MenuAccess = requestDetails.MenuAccess;
            request.BusinessJustification = requestDetails.BusinessJustification;
            request.RequestType = requestDetails.RequestType;
            request.Environment = requestDetails.Environment;
            request.UserAccessType = requestDetails.UserAccessType;
            request.AdditionalUserAccess = requestDetails.AdditionalUserAccess;
            request.UserType = requestDetails.UserType;
            request.TemporaryPosition = requestDetails.TemporaryPosition;
            request.TemporaryPostId = requestDetails.TemporaryPostId;

            request.UpdateStatus();

            await _context.SaveChangesAsync();

            return request.ToDetails();
        }

        public async Task<bool> LineManagerRequestApproval(int requestId, RequestApproverActionDetails requestApproverAction)
        {
            var request = await GetRequest(requestId);
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var approverAction = BuildApproverActionEntity(requestApproverAction, request, ApproverType.LineManager, ApproverActionType.LineManagerApproved);

                await _context.RequestApproverActions.AddAsync(approverAction);
                await _context.SaveChangesAsync();

                request.LineManagerApprover = approverAction;
                request.UpdateStatus();

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> LineManagerRequestRejection(int requestId, RequestApproverActionDetails requestApproverAction, string rejectionReason)
        {
            var request = await GetRequest(requestId);
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var approverAction = BuildApproverActionEntity(requestApproverAction, request, ApproverType.LineManager, ApproverActionType.LineManagerRejected);

                await _context.RequestApproverActions.AddAsync(approverAction);
                await _context.SaveChangesAsync();

                request.RejectionReason = rejectionReason;
                request.UpdateStatus();

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> ICTManagerRequestApproval(int requestId, RequestApproverActionDetails requestApprover)
        {
            var request = await GetRequest(requestId);
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var approver = BuildApproverActionEntity(requestApprover, request, ApproverType.ICTManager, ApproverActionType.ICTManagerApproved);

                await _context.RequestApproverActions.AddAsync(approver);

                request.ICTManagerApprover = approver;
                request.UpdateStatus();

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> ICTManagerRequestRejection(int requestId, RequestApproverActionDetails requestApprover, string rejectionReason)
        {
            var request = await GetRequest(requestId);
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var approver = BuildApproverActionEntity(requestApprover, request, ApproverType.ICTManager, ApproverActionType.ICTManagerRejected);

                await _context.RequestApproverActions.AddAsync(approver);
                await _context.SaveChangesAsync();

                request.RejectionReason = rejectionReason;
                request.UpdateStatus();

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> HcSystemsAdminRequestRejection(int requestId, RequestApproverActionDetails requestApprover, string rejectionReason)
        {
            var request = await GetRequest(requestId);
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var approver = BuildApproverActionEntity(requestApprover, request, ApproverType.HCOfficer, ApproverActionType.HcOfficerRejected);

                await _context.RequestApproverActions.AddAsync(approver);
                await _context.SaveChangesAsync();

                request.RejectionReason = rejectionReason;
                request.UpdateStatus();

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> TrainingCenterRequestVerification(int requestId, RequestApproverActionDetails requestApprover, DateTime trainingDate, string verifiedBy)
        {
            var request = await GetRequest(requestId);
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var approval = BuildApproverActionEntity(requestApprover, request, ApproverType.TrainingCenterRepresentative, ApproverActionType.TrainingVerified);

                await _context.RequestApproverActions.AddAsync(approval);
                await _context.SaveChangesAsync();

                request.TrainingApprover = approval;
                request.TrainingCompletionDate = trainingDate;
                request.UpdateStatus();

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }


        public async Task<bool> HcOfficerRequestImplementation(int requestId, RequestApproverActionDetails requestApprover, DateTime accessImplementationDate, long ellipseUserId)
        {
            var request = await GetRequest(requestId);
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var approver = BuildApproverActionEntity(requestApprover, request, ApproverType.HCOfficer, ApproverActionType.HcOfficerImplemented);

                await _context.RequestApproverActions.AddAsync(approver);
                await _context.SaveChangesAsync();

                request.HcOfficerApprover = approver;
                request.EllipseUserId = ellipseUserId;
                request.RequestClosed = true;
                request.UpdateStatus();

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> UnverifiedTraining(int requestId, RequestApproverActionDetails requestApprover, string rejectionReason = null)
        {
            var request = await GetRequest(requestId);
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var approver = BuildApproverActionEntity(requestApprover, request, ApproverType.TrainingCenterRepresentative, ApproverActionType.TrainingUnverified);

                await _context.RequestApproverActions.AddAsync(approver);
                await _context.SaveChangesAsync();

                request.RejectionReason = rejectionReason;
                request.UpdateStatus();

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private async Task<Request> GetRequest(int requestId)
        {
            var request = await _context.Requests
                .FindAsync(requestId);

            if (request == null)
                throw new KeyNotFoundException($"Request with Id {requestId} was not found.");

            return request;
        }

        private static RequestApproverAction BuildApproverActionEntity(RequestApproverActionDetails requestApprover, Request request, ApproverType approverType, ApproverActionType approverActionType)
        {
            if (requestApprover == null)
                throw new ArgumentException("RequestApprovalDetails cannot be null.", nameof(requestApprover));

            return requestApprover.ToEntity(request, approverType, approverActionType);
        }
    }
}