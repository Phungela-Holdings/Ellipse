using Ellipse.Shared.DTOs;
using Ellipse.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ellipse.API.Controllers
{
    [Route("api/[controller]/{action}/")]
    [ApiController]
    public class RequestApprovalController : ControllerBase
    {
        private readonly IRequestApprovalService _requestApprovalService;
        private readonly ILogger<RequestApprovalController> _logger;

        public RequestApprovalController(
            IRequestApprovalService requestApprovalService,
            ILogger<RequestApprovalController> logger)
        {
            _requestApprovalService = requestApprovalService;
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<bool> CreateApprovals(RequestApprovalDetails requestApprovalDetails)
        {
            try
            {
                var result = _requestApprovalService.CreateApprovals(requestApprovalDetails);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "An error occurred while creating request approval.");
                throw;
            }
        }

        [HttpGet]
        public ActionResult<List<RequestApprovalDetails>> GetApprovalsForRequest(int requestId)
        {
            try
            {
                var result = _requestApprovalService.GetApprovalsForRequest(requestId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "An error occurred while retrieving request approvals.");
                throw;
            }
        }
    }
}