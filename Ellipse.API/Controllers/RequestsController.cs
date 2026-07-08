using Ellipse.Shared.DTOs.Request;
using Ellipse.Shared.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<List<RequestDetails>> GetRequests()
        {
            try
            {
                return await _requestServices.GetRequests();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
