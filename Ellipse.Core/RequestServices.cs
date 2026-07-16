using Ellipse.Core.Extensions;
using Ellipse.Data;
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
                    //contractor = requestDetails.ContractorDetails.ToEntity(); ToDo : implement mapping from ContractorDetails to Contractor entity
                    
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

        public Task<RequestDetails> GetRequest(int requestId)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<List<RequestDetails>> SearchRequest(string searchString)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<RequestDetails> UpdateRequest(RequestDetails requestDetails)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<bool> LineManagerRequestApproval(int requestId, RequestApprovalDetails requestApproval)
        {
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

        public Task<bool> TrainingCenterRequestVerification(int requestId, RequestApprovalDetails requestApproval, DateTime trainingDate, string verifiedBy)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<bool> TrainingCenterRequestUnverified(int requestId, RequestApprovalDetails requestApproval, string rejectionReason)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<bool> HcSystemsAdminRequestImplementation(int requestId, RequestApprovalDetails requestApproval, DateTime accessImplementationDate, string ellipseUserId)
        {
            // TODO: implement
            throw new NotImplementedException();
        }

        public Task<bool> HcSystemsAdminRequestRejections(int requestId, RequestApprovalDetails requestApproval, string rejectionReason)
        {
            // TODO: implement
            throw new NotImplementedException();
        }
    }
}