using Ellipse.Core.Extensions;
using Ellipse.Data;
using Ellipse.Data.Entities;
using Ellipse.Shared.DTOs;
using Ellipse.Shared.DTOs.Request;
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

            var transaction = await _context.Database.BeginTransactionAsync();
            var request = requestDetails.RequestDetails.ToEntity();

            if (requestDetails.EmployeeDetails != null)
            {
                var employee = _context.Employees.Find(requestDetails.EmployeeDetails.EmailAddress);

                if (employee == null)
                {
                    //employee = requestDetails.EmployeeDetails.ToEntity(); ToDo : implement mapping from EmployeeDetails to Employee entity

                    await _context.Employees.AddAsync(employee);
                    await _context.SaveChangesAsync();

                    request.Employee = employee;
                }
            }

            if (requestDetails.ContractorDetails != null)
            {
                var contractor = _context.Contractors.Find(requestDetails.ContractorDetails.Id);

                if (contractor == null)
                {
                    contractor = requestDetails.ContractorDetails.ToEntity();

                    await _context.Contractors.AddAsync(contractor);
                    await _context.SaveChangesAsync();

                    request.Contractor = contractor;
                }
            }

            request.UpdateStatus();
            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();

            return request.ToDetails();
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
            //To do confirm if we have all the fields to search for in the request entity and add them to the where clause above
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
            //return await SetApprovalFlag(requestId, r => r.LineManagerApproved = true);
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<bool> LineManagerRequestRejection(int requestId, RequestApprovalDetails requestApproval, string rejectionReason)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<bool> ICTManagerRequestApproval(int requestId, RequestApprovalDetails requestApproval)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<bool> ICTManagerRequestRejection(int requestId, RequestApprovalDetails requestApproval, string rejectionReason)
        {
            // TODO: implement
            throw new NotImplementedException();
        }


        public async Task<bool> HcSystemsAdminRequestRejections(int requestId, string rejectionReason = null)
        {
            //return await SetApprovalFlag(requestId, r => r.HCSystemsAdminApproved = false);
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<bool> TrainingCenterRequestVerification(int requestId, RequestApprovalDetails requestApproval, DateTime trainingDate, string verifiedBy)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public async Task<bool> HcSystemsAdminRequestRejections(int requestId, RequestApprovalDetails requestApproval, string rejectionReason = null)
        {
            var request = await _context.Requests
                .FirstOrDefaultAsync(r => r.Id == requestId);

            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<bool> HcSystemsAdminRequestImplementation(int requestId, RequestApprovalDetails requestApproval, DateTime accessImplementationDate, string ellipseUserId)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<bool> TrainingCenterRequestUnverified(int requestId, RequestApprovalDetails requestApproval, string rejectionReason = null)
        {
            throw new NotImplementedException();
        }
    }
}