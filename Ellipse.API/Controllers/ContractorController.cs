using Ellipse.Shared.DTOs.Contract;
using Ellipse.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ellipse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractorController : ControllerBase
    {
        private readonly IContractorServices _contractorServices;
        private readonly ILogger<ContractorController> _logger;

        public ContractorController(
            IContractorServices contractorServices,
            ILogger<ContractorController> logger)
        {
            _contractorServices = contractorServices;
            _logger = logger;
        }

        // POST: api/contractors
        [HttpPost]
        public async Task<ActionResult> CreateContractor([FromBody] ContractorDetails contractorDetails)
        {
            try
            {
                var result = await _contractorServices.CreateContractorAsync(contractorDetails);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "An error occurred while creating contractor.");
                throw;
            }
        }
        // GET: api/contractors/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ContractorDetails>> GetContractorById(int id)
        {
            try
            {
                var contractor = await _contractorServices.GetContractorByIdAsync(id);

                if (contractor == null)
                {
                    return NotFound();
                }

                return Ok(contractor);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "An error occurred while retrieving contractor.");
                throw;
            }
        }

        // PUT: api/contractors
        [HttpPut]
        public async Task<ActionResult> UpdateContractor([FromBody] ContractorDetails contractorDetails)
        {
            try
            {
                var result = await _contractorServices.UpdateContractorAsync(contractorDetails);

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "An error occurred while updating contractor.");
                throw;
            }
        }

            // DELETE: api/contractors/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContractor(int id)
        {
            try
            {
                var result = await _contractorServices.DeleteContractorAsync(id);

                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "An error occurred while deleting contractor.");
                throw;
            }
        }
    }
}
