using Ellipse.Shared.DTOs.Request;
using Ellipse.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // fixes missing ILogger reference

namespace Ellipse.API.Controllers
{
    [Route("api/[controller]/{action}/")]
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
                _logger.LogError(ex, "Failed to retrieve requests.");
                return StatusCode(500, "An error occurred while retrieving requests.");
            }
        }
    }
}