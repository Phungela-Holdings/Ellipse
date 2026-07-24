using Ellipse.Shared.DTOs.Request;
using Ellipse.Shared.DTOs.RequestApproverAction;
using Ellipse.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ellipse.API.Controllers
{
    [Route("api/[controller]/[action]/")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly IRequestServices _requestServices;
        private readonly ILogger<RequestsController> _logger;

        public RequestsController(IRequestServices requestServices, ILogger<RequestsController> logger)
        {
            _requestServices = requestServices;
            _logger = logger;
        }

        public async Task<ActionResult<RequestDetails>> CreateRequest(NewRequestDetails requestDetails)
        {
            try
            {
                var results = await _requestServices.CreateRequest(requestDetails);

                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                //To do add proper error messages
                throw;
            }
        }

        public async Task<ActionResult<RequestDetails>> GetRequestDetails(int requestId)
        {
            try
            {
                var results = await _requestServices.GetRequestDetails(requestId);

                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                //To do add proper error messages
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<RequestDetails>>> GetRequests()
        {
            try
            {
                var result = await _requestServices.GetRequests();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving requests.");
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> HcOfficerRequestImplementation(RequestApproverActionDetails requestApprover, DateTime accessImplementationDate, long ellipseUserId)
        {
            try
            {
                var results = await _requestServices.HcOfficerRequestImplementation(requestApprover, accessImplementationDate, ellipseUserId);

                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                //To do add proper error messages
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> HcSystemsAdminRequestRejection(RequestApproverActionDetails requestApprover)
        {
            try
            {
                var results = await _requestServices.HcSystemsAdminRequestRejection(requestApprover);

                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                //To do add proper error messages
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> ICTManagerRequestApproval(RequestApproverActionDetails requestApprover)
        {
            try
            {
                var results = await _requestServices.ICTManagerRequestApproval(requestApprover);

                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                //To do add proper error messages
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> ICTManagerRequestRejection(RequestApproverActionDetails requestApprovern)
        {
            try
            {
                var results = await _requestServices.ICTManagerRequestRejection(requestApprovern);

                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                //To do add proper error messages
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> LineManagerRequestApproval(RequestApproverActionDetails requestApprover)
        {
            try
            {
                var results = await _requestServices.LineManagerRequestApproval(requestApprover);

                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                //To do add proper error messages
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> LineManagerRequestRejection(RequestApproverActionDetails requestApprover)
        {
            try
            {
                var results = await _requestServices.LineManagerRequestRejection(requestApprover);

                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                //To do add proper error messages
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<RequestDetails>>> SearchRequest(string searchString)
        {
            try
            {
                var results = await _requestServices.SearchRequest(searchString);

                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                //To do add proper error messages
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> TrainingCenterRequestVerification(RequestApproverActionDetails requestApprover, DateTime trainingDate, string verifiedBy)
        {
            try
            {
                var results = await _requestServices.TrainingCenterRequestVerification(requestApprover, trainingDate, verifiedBy);

                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                //To do add proper error messages
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<bool>> UnverifiedTraining(RequestApproverActionDetails requestApprover)
        {
            try
            {
                var results = await _requestServices.UnverifiedTraining(requestApprover);

                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                //To do add proper error messages
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<RequestDetails>> UpdateRequest(RequestDetails requestDetails)
        {
            try
            {
                var results = await _requestServices.UpdateRequest(requestDetails);

                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                //To do add proper error messages
                throw;
            }
        }
    }
}