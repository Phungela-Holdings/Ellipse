using Ellipse.Shared.DTOs;
using Ellipse.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ellipse.API.Controllers
{
    [Route("api/[controller]/{action}/")]
    [ApiController]
    public class RequestApprovalController : ControllerBase
    {
        private readonly IRequestApproverActionService _requestApproverActionService;
        private readonly ILogger<RequestApprovalController> _logger;

        public RequestApprovalController(
            IRequestApproverActionService requestApproverActionService,
            ILogger<RequestApprovalController> logger)
        {
            _requestApproverActionService = requestApproverActionService;
            _logger = logger;
        }

        [HttpPost]
        public ActionResult<bool> CreateApprovals(RequestApproverActionDetails requestApproverActionDetails)
        {
            try
            {
                var result = _requestApproverActionService.CreateApproverActionAsync(requestApproverActionDetails);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "An error occurred while creating request approval.");
                throw;
            }
        }

        [HttpGet]
        public ActionResult<List<RequestApproverActionDetails>> GetApprovalsForRequest(int requestId)
        {
            try
            {
                var result = _requestApproverActionService.GetApproverActionForRequestAsync(requestId);
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